using System;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.AdapterConsole.DataContracts;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts;
using TechnoLogica.RegiX.AdapterConsole.Services.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.Services.Impl
{
    public class RolesService : ABaseService<RolesInDto, RolesOutDto, AspNetRoles, int, RegiXAdapterConsoleContext>,
        IRolesService
    {
        private readonly IOperationsToRolesRepository operationsToRolesRepository;

        public RolesService(IRolesRepository aBaseRepository, IOperationsToRolesRepository operationsToRolesRepository)
            : base(aBaseRepository)
        {
            this.operationsToRolesRepository = operationsToRolesRepository;
        }

        public override RolesOutDto Insert(RolesInDto aInDto)
        {
            try
            {
                //var mappedObj = MappingTools.MapTo<RolesInDto, AspNetRoles>(aInDto);
                var mappedObj = new AspNetRoles {Name = aInDto.Name};

                var resultObj = _baseRepository.Insert(mappedObj);
                var operationsIds = aInDto.ReportIds;
                foreach (var operationId in operationsIds)
                {
                    var operation = new OperationsToRoles {AdapterOperationId = operationId, RoleId = resultObj.Id};
                    operationsToRolesRepository.Insert(operation);
                }

                _baseRepository.GetDbContext().SaveChanges();
                return MappingTools.MapTo<AspNetRoles, RolesOutDto>(resultObj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override RolesOutDto Update(int aId, RolesInDto aInDto)
        {
            var repoObj = _baseRepository.Select(aId);
            if (repoObj == null) throw new Exception("Object with id [" + aId + "] not found!");
            try
            {
                repoObj.Name = aInDto.Name;
                var resultObj = _baseRepository.Update(repoObj);

                //delete old reports
                var elements = operationsToRolesRepository
                    .SelectAll()
                    .Where(elem => elem.RoleId == aId)
                    .ToList();
                elements.ForEach(elem => { operationsToRolesRepository.Delete(elem.Id); });

                // insert new reports
                var operationsIds = aInDto.ReportIds;
                foreach (var operationId in operationsIds)
                {
                    var operation = new OperationsToRoles {AdapterOperationId = operationId, RoleId = resultObj.Id};
                    operationsToRolesRepository.Insert(operation);
                }

                _baseRepository.GetDbContext().SaveChanges();

                return MappingTools.MapTo<AspNetRoles, RolesOutDto>(resultObj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        ///   The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            return false; //TODO: Should IsChildRecord return false ??
        }
    }
}