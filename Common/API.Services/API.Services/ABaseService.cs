using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Query.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechnoLogica.API.DataContracts;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services.QueryValidators;

namespace TechnoLogica.API.Services
{
    /// <summary>
    /// Helper to set MaxPageSize
    /// </summary>
    public static class BaseServiceConstants
    {
        /// <summary>
        /// MaxPageSize that could be set from config
        /// </summary>
        public static int MaxPageSize = Constants.MaxPageSize;
    }

    /// <summary>
    /// Defines the <see cref="ABaseService{S, U, V, P}" />
    /// </summary>
    /// <typeparam name="S"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="P"></typeparam>
    public abstract class ABaseService<S, U, V, P, Db> : IBaseService<S, U, V, P>
        where V : class
        where P : struct
        where Db : DbContext
    {
        /// <summary>
        /// MaxPageSize that could be set from config
        /// </summary>
        private static int MaxPageSize = BaseServiceConstants.MaxPageSize;

        /// <summary>
        /// Defines the QUERY_OPTIONS_SEPARATOR
        /// </summary>
        private const char QUERY_OPTIONS_SEPARATOR = '&';

        /// <summary>
        /// Defines the QUERY_OPTIONS_DELIMITER
        /// </summary>
        private const char QUERY_OPTIONS_DELIMITER = '=';

        /// <summary>
        /// Defines the QUERY_OPTIONS_SKIP
        /// </summary>
        private const string QUERY_OPTIONS_SKIP = "$skip";

        /// <summary>
        /// Defines the QUERY_OPTIONS_TOP
        /// </summary>
        private const string QUERY_OPTIONS_TOP = "$top";

        /// <summary>
        /// Defines the QUESTION_MARK
        /// </summary>
        private const char QUESTION_MARK = '?';

        /// <summary>
        /// Defines the _baseRepository
        /// </summary>
        protected IBaseRepository<V, P, Db> _baseRepository;

        // Dictionary, в което се описва mapping-а между имената на полетата в dto-to и entity-то
        /// <summary>
        /// Defines the dtoFieldsToEntityFields
        /// </summary>
        protected Dictionary<string, string> dtoFieldsToEntityFields;

        /// <summary>
        /// Defines the queryValidator
        /// </summary>
        protected FilterQueryValidator queryValidator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ABaseService{S, U, V}"/> class.
        /// </summary>
        /// <param name="aBaseRepository">The aBaseRepository<see cref="IBaseRepository{V}"/></param>
        /// <param name="aQueryValidator">Query validator - used to validate the OData search properties</param>
        protected ABaseService(IBaseRepository<V, P, Db> aBaseRepository, FilterQueryValidator aQueryValidator = null)
        {
            this._baseRepository = aBaseRepository;
            this.queryValidator = aQueryValidator ?? new DefaultQueryValidator<V>();
            this.dtoFieldsToEntityFields = new Dictionary<string, string>();
            this.PopulateDtoToEntityFieldsMapping();
        }

        /// <summary>
        /// The SelectAll
        /// </summary>
        /// <param name="aOptions">The aOptions<see cref="ODataQueryOptions{V}"/></param>
        /// <returns>The <see cref="List{U}"/></returns>
        public virtual List<U> SelectAll(ODataQueryOptions<V> aOptions)
        {
            IQueryable<V> query = this._baseRepository.SelectAll();
            var resultQuery = this.ApplyOData(query, aOptions);
            // Връща query обект от repository-то
            List<V> repoList = ((IQueryable<V>)resultQuery).ToList();
            return MappingTools.MapToList<V, U>(repoList);
        }

        public virtual CustomPageResult<U> SelectAllWithPagination(ODataQueryOptions<V> aOptions)
        {
            IQueryable<V> baseQuery = this.GetSelectAllQueriable();
            var resultQuery = this.ApplyOData(baseQuery, aOptions);
            return this.CreatePageResult(aOptions, baseQuery, (IQueryable<V>)resultQuery);
        }

        protected CustomPageResult<U> CreatePageResult(ODataQueryOptions<V> aQueryOptions, IQueryable<V> baseQuery,
                                                     IQueryable<V> resultQuery)
        {
            CustomPageResult<U> pageResult = new CustomPageResult<U>();
            pageResult.PerPage = this.CalculateTop(aQueryOptions);
            pageResult.Total = this.GetTotalPages(aQueryOptions, baseQuery);
            pageResult.CurrentPage = this.CalculateCurrentPage(aQueryOptions);
            pageResult.LastPage = this.CalculateLastPage(aQueryOptions, pageResult.Total);
            if (pageResult.LastPage > 0 && (pageResult.CurrentPage > pageResult.LastPage))
            {
                pageResult.CurrentPage = pageResult.LastPage;
                int lastPageSkip = (pageResult.LastPage * pageResult.PerPage) - (pageResult.PerPage);
                ODataQueryOptions queryOptionsWithLastPageItems = this.SetSkip(aQueryOptions, lastPageSkip);
                IQueryable<V> queryWithLastPageItems = (IQueryable<V>)queryOptionsWithLastPageItems.ApplyTo(baseQuery);
                pageResult.Data = MappingTools.MapToList<V, U>(queryWithLastPageItems.ToList());
            }
            else
            {
                pageResult.Data = MappingTools.MapToList<V, U>(resultQuery.ToList());
            }

            return pageResult;
        }

        /// <summary>
        /// The GetTotalPages
        /// </summary>
        /// <param name="aQueryOptions">The aQueryOptions<see cref="ODataQueryOptions{V}"/></param>
        /// <returns>The <see cref="int"/></returns>
        protected int GetTotalPages(ODataQueryOptions<V> aQueryOptions, IQueryable<V> aQueriable)
        {
            var newQueryOptions = (ODataQueryOptions<V>)RemoveTopSkip(aQueryOptions);
            IQueryable queryable = newQueryOptions.ApplyTo(aQueriable);
            return ((IQueryable<V>)queryable).Count();
        }

        protected virtual IQueryable<V> GetSelectAllQueriable()
        {
            return this._baseRepository.SelectAll();
        }

        /// <summary>
        /// The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal"/></param>
        /// <returns>The <see cref="U"/></returns>
        public virtual U Select(P aId)
        {
            V repoObj = this._baseRepository.Select(aId);
            return MappingTools.MapTo<V, U>(repoObj);
        }

        /// <summary>
        /// The Insert
        /// </summary>
        /// <param name="aInDto">The aInDto<see cref="S"/></param>
        /// <returns>The <see cref="U"/></returns>
        public virtual U Insert(S aInDto)
        {
            V mappedObj = MappingTools.MapTo<S, V>(aInDto);
            V resultObj = this._baseRepository.Insert(mappedObj);
            this._baseRepository.GetDbContext().SaveChanges();
            return MappingTools.MapTo<V, U>(resultObj);
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal"/></param>
        /// <param name="aInDto">The aInDto<see cref="S"/></param>
        /// <returns>The <see cref="U"/></returns>
        public virtual U Update(P aId, S aInDto)
        {
            V repoObj = this._baseRepository.Select(aId);
            if (repoObj == null)
            {
                throw new Exception("Object with id [" + aId + "] not found!");
            }

            this.ValidateUpdate(repoObj, aInDto);

            repoObj = MappingTools.MapTo(aInDto, repoObj);
            repoObj = this._baseRepository.Update(repoObj);
            this._baseRepository.GetDbContext().SaveChanges();
            return MappingTools.MapTo<V, U>(repoObj);
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal"/></param>
        /// <returns>The <see cref="U"/></returns>
        public virtual U Delete(P aId)
        {
            V repoObj = this._baseRepository.Select(aId);
            if (repoObj == null)
            {
                throw new Exception("Object with id [" + aId + "] not found!");
            }

            List<string> parentsList = new List<string>();
            if (this.IsChildRecord(aId, parentsList))
            {
                string errorMessage = this.FormatParentsMessage(parentsList);
                throw new Exception(errorMessage);
            }

            V deletedObj = this._baseRepository.Delete(aId);
            this._baseRepository.GetDbContext().SaveChanges();
            return MappingTools.MapTo<V, U>(deletedObj);
        }

        protected virtual void ValidateUpdate(V repoObj, S aInDto)
        {
        }

        // Този метод се override-ва във всеки child и в него се попълват полетата, които трябва 
        // да бъдат мапнати към съответното име в entity-то (използва се dtoFieldsToEntityFields)
        protected abstract void PopulateDtoToEntityFieldsMapping();

        /// <summary>
        /// The FormatParentsMessage
        /// </summary>
        /// <param name="aList"></param>
        /// <returns></returns>
        protected string FormatParentsMessage(List<string> aList)
        {
            string message = "Object is referenced by: ";
            foreach (string parent in aList)
            {
                message += "[" + parent + "]";
            }
            return "Child record found! " + message;
        }

        /// <summary>
        /// The RemoveTopSkip
        /// </summary>
        /// <param name="aOptions">The aOptions<see cref="ODataQueryOptions{V}"/></param>
        /// <returns>The <see cref="ODataQueryOptions"/></returns>
        protected ODataQueryOptions RemoveTopSkip(ODataQueryOptions<V> aOptions)
        {
            var uri = new Uri(aOptions.Request.GetDisplayUrl());
            var queryParameters = uri.Query
                                    .TrimStart(new char[] { QUERY_OPTIONS_DELIMITER, QUESTION_MARK })
                                    .Split(QUERY_OPTIONS_SEPARATOR)
                                    .ToDictionary(e => e.Split(QUERY_OPTIONS_DELIMITER).FirstOrDefault(),
                                    e => e.Split(QUERY_OPTIONS_DELIMITER).LastOrDefault());
            var newQueryOptions = new StringBuilder();
            foreach (string key in queryParameters.Keys)
            {

                if (key != QUERY_OPTIONS_SKIP && key != QUERY_OPTIONS_TOP)
                {
                    AppendKeyValue(newQueryOptions, key, queryParameters[key]);
                }
            }

            return this.CreateNewOdataQueryOptions(aOptions, newQueryOptions.ToString());
        }

        /// <summary>
        /// Checks whether the object is a child record
        /// </summary>
        /// <param name="aId"></param>
        /// <param name="aParentsList"></param>
        /// <returns></returns>
        protected abstract bool IsChildRecord(P aId, List<string> aParentsList);

        protected virtual IQueryable ApplyOData(IQueryable<V> query, ODataQueryOptions<V> aOptions)
        {
            ODataQueryOptions<V> mappedFieldsQOptions = (ODataQueryOptions<V>)this.MapDtoToEntityFields(aOptions);
            if (mappedFieldsQOptions.Filter != null)
            {
                this.queryValidator.Validate(mappedFieldsQOptions.Filter, new ODataValidationSettings());
            }

            // Съхранява оформената заявка след прилагането на параметрите от url
            IQueryable resultQuery;
            // Сетва се default-ен размер на paging
            ODataQuerySettings querySetting = new ODataQuerySettings { PageSize = MaxPageSize };
            // Ако в url, няма top option за странициране или заявения top е повече от разрешения се прилага default-ния paging
            if (mappedFieldsQOptions.Top == null || mappedFieldsQOptions.Top.Value > MaxPageSize)
            {
                resultQuery = mappedFieldsQOptions.ApplyTo(query, querySetting);
            }
            else
            {
                // В противен случай се прилага paging-а от url параметъра
                resultQuery = mappedFieldsQOptions.ApplyTo(query);
            }

            return resultQuery;
        }

        // Имплементира логиката спрямо, 
        // която се заместват имената на dto полетата към имената на entity полетата
        /// <summary>
        /// The MapDtoToEntityFields
        /// </summary>
        /// <param name="aOptions">The aOptions<see cref="ODataQueryOptions{V}"/></param>
        /// <returns>The <see cref="ODataQueryOptions"/></returns>
        protected ODataQueryOptions MapDtoToEntityFields(ODataQueryOptions<V> aOptions)
        {
            var uri = new Uri(aOptions.Request.GetDisplayUrl());
            string newQueryOptions = uri.Query;
            foreach (var key in dtoFieldsToEntityFields.Keys)
            {
                string value = dtoFieldsToEntityFields[key];
                newQueryOptions = newQueryOptions.Replace(key, value);
            }

            return this.CreateNewOdataQueryOptions(aOptions, newQueryOptions);
        }

        protected int CalculateTop(ODataQueryOptions<V> aQueryOptions)
        {
            int top = Constants.MaxPageSize;
            if (aQueryOptions.Top != null && (aQueryOptions.Top.Value >= 0 && aQueryOptions.Top.Value < Constants.MaxPageSize))
            {
                top = aQueryOptions.Top.Value;
            }

            return top;
        }

        protected int CalculateLastPage(ODataQueryOptions<V> aQueryOptions, int aTotalElements)
        {
            int top = CalculateTop(aQueryOptions);
            if (top == 0)
            {
                return 0;
            }

            return (int)Math.Ceiling((aTotalElements) / (double)top);
        }

        protected int CalculateCurrentPage(ODataQueryOptions<V> aQueryOptions)
        {
            int skip = 0;
            int top = CalculateTop(aQueryOptions);
            if (top == 0)
            {
                return 0;
            }

            if (aQueryOptions.Skip != null)
            {
                skip = aQueryOptions.Skip.Value;
            }

            return ((int)(skip / (double)top)) + 1;
        }

        /// <summary>
        /// The AssignNewUri
        /// </summary>
        /// <param name="resultUri">The resultUri<see cref="Uri"/></param>
        /// <param name="aOptions">The aOptions<see cref="ODataQueryOptions{V}"/></param>
        private void AssignNewUri(Uri resultUri, ODataQueryOptions<V> aOptions)
        {
            aOptions.Request.Scheme = resultUri.Scheme;
            aOptions.Request.Host = HostString.FromUriComponent(resultUri.Host);
            aOptions.Request.Path = PathString.FromUriComponent(resultUri.AbsolutePath);
            aOptions.Request.QueryString = QueryString.FromUriComponent(resultUri.Query);
        }

        // Създава новият обект ODataQueryOptions, който се получава след съответната обработка
        private ODataQueryOptions CreateNewOdataQueryOptions(ODataQueryOptions<V> aOptions, string newQueryOptions)
        {
            var uri = new Uri(aOptions.Request.GetDisplayUrl());
            Uri baseResultUri = new Uri($"{uri.Scheme}://{uri.Authority}{uri.AbsolutePath}");
            Uri resultUri;
            if (newQueryOptions.StartsWith("?"))
            {
                resultUri = new Uri(baseResultUri.OriginalString + newQueryOptions);
            }
            else
            {
                resultUri = new Uri(baseResultUri.OriginalString + "?" + newQueryOptions);
            }


            this.AssignNewUri(resultUri, aOptions);
            var newOdataQueryOptions = (ODataQueryOptions)Activator.CreateInstance(aOptions.GetType(), aOptions.Context, aOptions.Request);
            return newOdataQueryOptions;
        }

        /// <summary>
        /// The AppendKeyValue
        /// </summary>
        /// <param name="aNewQueryOptions">The aNewQueryOptions<see cref="StringBuilder"/></param>
        /// <param name="aKey">The aKey<see cref="string"/></param>
        /// <param name="aValue">The aValue<see cref="object"/></param>
        private void AppendKeyValue(StringBuilder aNewQueryOptions, string aKey, object aValue)
        {
            aNewQueryOptions.Append(QUERY_OPTIONS_SEPARATOR);
            aNewQueryOptions.Append(aKey);
            aNewQueryOptions.Append(QUERY_OPTIONS_DELIMITER);
            aNewQueryOptions.Append(aValue);
        }

        private ODataQueryOptions SetSkip(ODataQueryOptions<V> aOptions, int skip)
        {
            var uri = new Uri(aOptions.Request.GetDisplayUrl());
            var queryParameters = uri.Query
                                    .TrimStart(new char[] { QUERY_OPTIONS_DELIMITER, QUESTION_MARK })
                                    .Split(QUERY_OPTIONS_SEPARATOR)
                                    .ToDictionary(e => e.Split(QUERY_OPTIONS_DELIMITER).FirstOrDefault(),
                                    e => e.Split(QUERY_OPTIONS_DELIMITER).LastOrDefault());
            var newQueryOptions = new StringBuilder();
            foreach (string key in queryParameters.Keys)
            {
                if (key != QUERY_OPTIONS_SKIP)
                {
                    AppendKeyValue(newQueryOptions, key, queryParameters[key]);
                }
            }

            AppendKeyValue(newQueryOptions, QUERY_OPTIONS_SKIP, skip);
            return this.CreateNewOdataQueryOptions(aOptions, newQueryOptions.ToString());
        }
    }
}
