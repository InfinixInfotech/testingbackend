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
    public class QualificationService : IQualificationService
    {
        private readonly IQualificationRepository _qualificationRepository;
        private readonly SequenceGenerator _sequenceGenerator;
        public QualificationService(IQualificationRepository qualificationRepository,SequenceGenerator sequenceGenerator) 
        { 
            _qualificationRepository = qualificationRepository;
            _sequenceGenerator = sequenceGenerator;
        }
        public async Task<Response> InsertQualificationAsync(Qualification qualification)
        {
            try
            {
                qualification.Id = _sequenceGenerator.GetNextSequence("Demo_Qualification", "Qualification_Sequence");
                await _qualificationRepository.InsertQualificationAsync(qualification);
                return new Response { Success = true, Message = "Qualification added successfully." };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> UpdateQualificationByIdAsync(Qualification qualification)
        {
            try
            { // Ensure ID is set
                await _qualificationRepository.UpdateQualificationByIdAsync(qualification);
                return new Response { Success = true, Message = "Qualification updated successfully." };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> DeleteQualificationByIdAsync(int id)
        {
            try
            {
                await _qualificationRepository.DeleteQualificationByIdAsync(id);
                return new Response { Success = true, Message = "Qualification deleted successfully." };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> GetAllQualificationAsync()
        {
            try
            {
                var data = await _qualificationRepository.GetAllQualificationAsync();
                return new Response { Success = true, Data = data };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
        public async Task<Response> GetQualificationById(int id)
        {
            try
            {
                var user = await _qualificationRepository.GetQualificationById(id);
                if (user == null)
                {
                    return new Response { Success = false, Error = "Qualification not found." };
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
