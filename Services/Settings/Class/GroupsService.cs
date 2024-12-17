using Common;
using Models.Common;
using Models.Settings;
using Repository.Common;
using Repository.Settings.IClass;
using Services.Settings.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Settings.Class
{
    public class GroupsService : IGroupsService
    {
        private readonly IGroupsRepository _groupsRepository;
        private readonly SequenceGenerator _sequenceGenerator;
        private readonly IIdentifierService _identifierService;

        public GroupsService(IGroupsRepository groupsRepository, SequenceGenerator sequenceGenerator, IIdentifierService identifierService) 
        { 
            _groupsRepository = groupsRepository;
            _sequenceGenerator = sequenceGenerator;
            _identifierService = identifierService;
        }
        public async Task<Response> InsertAsync(Groups model)
        {
            try
            {
                model.Id = _sequenceGenerator.GetNextSequence("Demo_group", "Demogroup_Sequence");
                model.GroupId = await GetNextIdentifierAsync();
                await _groupsRepository.InsertAsync(model);
                return new Response { Success = true, Message = "Add Group added successfully" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> UpdateByIdAsync(Groups model)
        {
            try
            {
                await _groupsRepository.UpdateByIdAsync(model);
                return new Response { Success = true, Message = "Add Group updated successfully" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> DeleteByIdAsync(int id)
        {
            try
            {
                await _groupsRepository.DeleteByIdAsync(id);
                return new Response { Success = true, Message = "Add Group deleted successfully" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> GetAllAsync()
        {
            try
            {
                var data = await _groupsRepository.GetAllAsync();
                return new Response { Success = true, Data = data };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
        public async Task<Response> GetGroupsById(int id)
        {
            try
            {
                var user = await _groupsRepository.GetGroupsById(id);
                if (user == null)
                {
                    return new Response { Success = false, Error = "groups not found." };
                }
                return new Response { Success = true, Data = user };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
        public async Task<string> GetNextIdentifierAsync()
        {
            long nextIdNumber = _sequenceGenerator.GetNextSequence("Demo_GroupIDNo", "GroupIDNo");
            var nextId = $"INFGRP{nextIdNumber:D2}";
            await _identifierService.InsertIdentifierAsync(new InfinixId { Id = nextId });

            return nextId;
        }
        public async Task<Response> GetAllGroupNameAndID()
        {
            try
            {
                var users = await _groupsRepository.GetAllGroupNameAndID();

                // Map Users to GetUsers
                var data = users.Select(user => new GroupDetails
                {
                    GroupId = user.GroupId,
                    GroupName = user.GroupName,
                }).ToList();

                return new Response { Success = true, Data = data };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
    }
}
