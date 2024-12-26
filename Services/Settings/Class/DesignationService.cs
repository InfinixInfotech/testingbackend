using Common;
using Models.Settings;
using Repository.Settings.Class;
using Repository.Settings.IClass;
using Services.Settings.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Settings.Class
{
    public class DesignationService : IDesignationService
    {
        private readonly IDesignationRepository _designationRepository;
        private readonly SequenceGenerator _sequenceGenerator;
        public DesignationService(IDesignationRepository designationRepository, SequenceGenerator sequenceGenerator) 
        { 
            _designationRepository = designationRepository;
            _sequenceGenerator = sequenceGenerator;
        }
        public async Task<Response> CreateDesignation(Designation designation)
        {
            var response = new Response();
            try
            {
                designation.Id = _sequenceGenerator.GetNextSequence("Demo_designation", "designation_Sequence");
                await _designationRepository.CreateDesignation(designation);
                response.Success = true;
                response.Message = "designation created successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
            }
            return response;
        }

        public async Task<Response> UpdateDesignation(Designation designation)
        {
            var response = new Response();
            try
            {
                var existingDepartment = await _designationRepository.GetDesignationById(designation.Id);
                if (existingDepartment == null)
                {
                    response.Success = false;
                    response.Error = "designation not found.";
                    return response;
                }
                await _designationRepository.UpdateDesignation(designation);
                response.Success = true;
                response.Message = "designation updated successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
            }
            return response;
        }

        public async Task<Response> DeleteDesignation(int id)
        {
            var response = new Response();
            try
            {
                var existingDepartment = await _designationRepository.GetDesignationById(id);
                if (existingDepartment == null)
                {
                    response.Success = false;
                    response.Error = "designation not found.";
                    return response;
                }

                await _designationRepository.DeleteDesignation(id);
                response.Success = true;
                response.Message = "designation deleted successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
            }
            return response;
        }

        public async Task<Response> GetAllDesignation()
        {
            var response = new Response();
            try
            {
                var departments = await _designationRepository.GetAllDesignation();
                response.Success = true;
                response.Message = "designation fetched successfully.";
                response.Data = departments;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
            }
            return response;
        }
        public async Task<Response> GetDesignationById(int id)
        {
            try
            {
                var user = await _designationRepository.GetDesignationById(id);
                if (user == null)
                {
                    return new Response { Success = false, Error = "designation not found." };
                }
                return new Response { Success = true, Data = user };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
    }
}

