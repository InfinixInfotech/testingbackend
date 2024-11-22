using Common;
using Models.Settings;
using Repository.Demo.IClass;
using Repository.Settings.IClass;
using Services.Settings.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Settings.Class
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly SequenceGenerator _sequenceGenerator;
        public DepartmentService(IDepartmentRepository departmentRepository,SequenceGenerator sequenceGenerator) 
        {
            _departmentRepository = departmentRepository;
            _sequenceGenerator = sequenceGenerator;
        }
        public async Task<Response> CreateDepartmentAsync(Department department)
        {
            var response = new Response();
            try
            {
                department.Id = _sequenceGenerator.GetNextSequence("Demo_department", "department_Sequence");
                await _departmentRepository.CreateDepartmentAsync(department);
                response.Success = true;
                response.Message = "Department created successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
            }
            return response;
        }

        public async Task<Response> UpdateDepartmentAsync(int id, Department department)
        {
            var response = new Response();
            try
            {
                var existingDepartment = await _departmentRepository.GetByIdDepartmentAsync(id);
                if (existingDepartment == null)
                {
                    response.Success = false;
                    response.Error = "Department not found.";
                    return response;
                }

                department.Id = id;
                await _departmentRepository.UpdateDepartmentAsync(id, department);
                response.Success = true;
                response.Message = "Department updated successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
            }
            return response;
        }

        public async Task<Response> DeleteDepartmentAsync(int id)
        {
            var response = new Response();
            try
            {
                var existingDepartment = await _departmentRepository.GetByIdDepartmentAsync(id);
                if (existingDepartment == null)
                {
                    response.Success = false;
                    response.Error = "Department not found.";
                    return response;
                }

                await _departmentRepository.DeleteDepartmentAsync(id);
                response.Success = true;
                response.Message = "Department deleted successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
            }
            return response;
        }

        public async Task<Response> GetAllDepartmentAsync()
        {
            var response = new Response();
            try
            {
                var departments = await _departmentRepository.GetAllDepartmentAsync();
                response.Success = true;
                response.Message = "Departments fetched successfully.";
                response.Data = departments;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
            }
            return response;
        }
        public async Task<Response> GetDepartmentById(int id)
        {
            try
            {
                var user = await _departmentRepository.GetByIdDepartmentAsync(id);
                if (user == null)
                {
                    return new Response { Success = false, Error = "Department not found." };
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
