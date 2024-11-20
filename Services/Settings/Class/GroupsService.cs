using Common;
using Models.Settings;
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

        public GroupsService(IGroupsRepository groupsRepository, SequenceGenerator sequenceGenerator) 
        { 
            _groupsRepository = groupsRepository;
            _sequenceGenerator = sequenceGenerator;
        }
        public async Task<Response> InsertAsync(Groups model)
        {
            try
            {
                model.Id = _sequenceGenerator.GetNextSequence("Demo_group", "Demogroup_Sequence");
                await _groupsRepository.InsertAsync(model);
                return new Response { Success = true, Message = "Add Group added successfully" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> UpdateByIdAsync(int id, Groups model)
        {
            try
            {
                await _groupsRepository.UpdateByIdAsync(id, model);
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
    }
}
