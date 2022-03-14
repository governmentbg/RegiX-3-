using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="RegisterAdaptersRepository" />
    /// </summary>
    public class RegisterAdaptersRepository : ABaseRepository<RegisterAdapters, decimal, RegiXContext>,
        IRegisterAdaptersRepository
    {
        protected IUserContext UserContext { get; private set; }

        public RegisterAdaptersRepository(RegiXContext aDbContext, IUserContext userContext)
            : base(aDbContext)
        {
            UserContext = userContext;
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{RegisterAdapters}" /></returns>
        public override IQueryable<RegisterAdapters> SelectAll()
        {
            var result =
             GetDbContext().Set<RegisterAdapters>()
                .Include(r => r.Register)
                .AsQueryable();

            result = UserContext.FilterByAdministration(result,
                    (r) => r.Register.AdministrationId);

            return result;
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="RegisterAdapters" /></returns>
        public override RegisterAdapters Select(decimal aId)
        {
            return this.SelectAll()
                .SingleOrDefault(r => r.RegisterAdapterId == aId);
        }

        public void Insert(RegisterAdapters aEntity, ApiServices apiServices)
        {
            using (var transaction = GetDbContext().Database.BeginTransaction())
            {
                try
                {
                    aEntity.Register = GetDbContext().Set<Registers>()
                        .Include(r => r.Administration)
                        .SingleOrDefault(x => x.RegisterId == aEntity.RegisterId);

                    GetDbContext().Set<RegisterAdapters>().Add(aEntity);

                    var administrationId = aEntity.Register.AdministrationId;
                    apiServices.AdministrationId = administrationId;

                    GetDbContext().Set<ApiServices>().Add(apiServices);

                    var apiServiceAdapterOperationsList = new List<ApiServiceAdapterOperations>();
                    foreach (var operation in aEntity.AdapterOperations)
                    {
                        var operationName = operation.Name;
                        var apiOperation = apiServices.ApiServiceOperations.First(x => x.Name == operationName);
                        var apiServiceAdapterOperation = new ApiServiceAdapterOperations
                        {
                            AdapterOperation = operation,
                            ApiServiceOperation = apiOperation
                        };
                        apiServiceAdapterOperationsList.Add(apiServiceAdapterOperation);
                    }

                    GetDbContext().Set<ApiServiceAdapterOperations>().AddRange(apiServiceAdapterOperationsList);
                    GetDbContext().SaveChanges();

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}