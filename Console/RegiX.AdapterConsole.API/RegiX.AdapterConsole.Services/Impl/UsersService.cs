using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.Users;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts;
using TechnoLogica.RegiX.AdapterConsole.Services.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.Services.Impl
{
    public class UsersService : ABaseService<UsersInDto, UsersOutDto, AspNetUsers, int, RegiXAdapterConsoleContext>,
        IUsersService
    {
        private readonly IMapper _mapper;
        private readonly IOperationToUserRepository _operationToUserRepository;
        private readonly IUsersToRolesRepository usersToRolesRepository;

        public UsersService(IUsersRepository aBaseRepository,
            IUsersToRolesRepository usersToRolesRepository,
            IOperationToUserRepository operationToUserRepository,
            IMapper mapper)
            : base(aBaseRepository)
        {
            this.usersToRolesRepository = usersToRolesRepository;
            _operationToUserRepository = operationToUserRepository;
            _mapper = mapper;
        }

        public override UsersOutDto Insert(UsersInDto aInDto)
        {
            try
            {
                var mappedObj = MappingTools.MapTo<UsersInDto, AspNetUsers>(aInDto);

                var resultObj = _baseRepository.Insert(mappedObj);

                var roleIds = aInDto.RoleIds;
                foreach (var roleId in roleIds)
                {
                    var userToRole = new AspNetUserRoles
                    {
                        RoleId = roleId,
                        UserId = resultObj.Id
                    };

                    usersToRolesRepository.Insert(userToRole);
                }

                _baseRepository.GetDbContext().SaveChanges();

                return MappingTools.MapTo<AspNetUsers, UsersOutDto>(resultObj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override UsersOutDto Update(int aId, UsersInDto aInDto)
        {
            var repoObj = _baseRepository.Select(aId);
            if (repoObj == null) throw new Exception("Object with id [" + aId + "] not found!");
            try
            {
                repoObj = MappingTools.MapTo(aInDto, repoObj);
                var resultObj = _baseRepository.Update(repoObj);

                //delete old roles
                usersToRolesRepository.DeleteAllRoles(resultObj.Id);

                //insert new roles
                var roleIds = aInDto.RoleIds;
                foreach (var roleId in roleIds)
                {
                    var roleUser = new AspNetUserRoles {UserId = resultObj.Id, RoleId = roleId};
                    usersToRolesRepository.Insert(roleUser);
                }

                _baseRepository.GetDbContext().SaveChanges();

                return MappingTools.MapTo<AspNetUsers, UsersOutDto>(resultObj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<UsersOutDto> GetUsersByOperation(int aId)
        {
            var usersWithAccess = _operationToUserRepository
                .SelectAll()
                .Where(u => u.Id == aId)
                .Select(u => u.UserId);

            var result = _baseRepository
                .SelectAll()
                .Where(u => usersWithAccess.Contains(u.Id))
                .ProjectTo<UsersOutDto>(_mapper.ConfigurationProvider).ToList();

            return result;
        }

        /// <summary>
        ///   The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            return false;
        }
    }
}