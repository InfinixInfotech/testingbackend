using Common;
using CsvHelper.Configuration;
using CsvHelper;
using DnsClient;
using Microsoft.AspNetCore.Http;
using Models.BulkLeads;
using Models.Common;
using Models.Settings;
using Repository.Settings.Class;
using Repository.Settings.IClass;
using Services.Settings.IClass;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using CsvHelper.TypeConversion;

namespace Services.Settings.Class
{
    public class UsersService : IUsersService
    {
        private readonly IGroupsRepository _groupsRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly SequenceGenerator _sequenceGenerator;
        public UsersService(IUsersRepository usersRepository, SequenceGenerator sequenceGenerator, IGroupsRepository groupsRepository)
        {
            _usersRepository = usersRepository;   
            _sequenceGenerator = sequenceGenerator;
            _groupsRepository = groupsRepository;
        }
        public async Task<Response> AddUsers(Users users)
        {
            try
            {
                var Emp = await _usersRepository.GeEmpCode(users.MobileNumber);
                if (Emp != null)
                {
                    return new Response
                    {
                        Success = true,
                        Message = "User already exist",
                        Data = Emp,
                    };
                }
                users.GroupId = await _groupsRepository.GetGroupIdByGroupName(users.GroupName);                
                var id = _sequenceGenerator.GetNextSequence("Demo_users", "Demousers_Sequence");
                users.Id = id;
                var splitValue = GenerateSplitValue(users);
                var seq = $"INF{splitValue}{id:D2}";
                users.EmployeeCode = seq ;
                users.UserName = seq;
                await _usersRepository.AddUsers(users);
                return new Response { Success = true, Message = "Users added successfully" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
        private string GenerateSplitValue(Users users)
        {
            // Extract the first name from FullName
            string firstName = users.FullName?.Split(' ')[0].ToLower();
            string abc = firstName.ToUpper();
            string dayPart = string.Empty;

            // Handle the DateOfBirth to extract the day part
            if (users.DateOfBirth.HasValue)
            {
                dayPart = users.DateOfBirth.Value.ToString("dd"); // Extract day part from valid DateOfBirth
            }
            else
            {
                // Provide a default or handle null DateOfBirth
                dayPart = "00"; // Default value for null date
            }

            return $"{abc}{dayPart}";
        }




        public async Task<Response> UpdateUsersById(Users model)
        {   
            try
            {
                await _usersRepository.UpdateUsersById(model);
                return new Response { Success = true, Message = "=Users updated successfully" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
        public async Task<Response> GetAllUsers()
        {
            try
            {
                var users = await _usersRepository.GetAllUsers();

                // Map Users to GetUsers
                var data = users.Select(user => new GetUsers
                {
                    FullName = user.FullName,
                    EmployeeCode = user.EmployeeCode,
                    MobileNumber = user.MobileNumber,
                    UserName = user.UserName,
                    Password = user.Password,
                    ReportingTo = user.ReportingTo,
                    GroupName = user.GroupName,
                    DepartmentName = user.DepartmentName,
                    DesignationName = user.DesignationName,
                    QualificationName = user.QualificationName,
                    Extension = user.Extension,
                    DateOfBirth = user.DateOfBirth,
                    DateOfJoining = user.DateOfJoining
                }).ToList();

                return new Response { Success = true, Data = data };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        } 
        public async Task<Response> GetUserById(int id)
        {
            try
            {
                var user = await _usersRepository.GetUserById(id);
                if (user == null)
                {
                    return new Response { Success = false, Error = "User not found." };
                }
                return new Response { Success = true, Data = user };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
        public async Task<Response> GetAllEmployeeCodeAndName()
        {
            try
            {
                var users = await _usersRepository.GetAllEmployeeCodeAndName();

                // Map Users to GetUsers
                var data = users.Select(user => new EmployeeDetails
                {
                    EmployeeName = user.EmployeeName,
                    EmployeeCode = user.EmployeeCode,                  
                }).ToList();

                return new Response { Success = true, Data = data };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> UploadBulkUser(BulkUser user)
        {
            try
            {
                var fileContent = await ConvertToFileContent(user.CsvUserFile);
                var users = await ProcessCsvFile(fileContent);

                foreach (var singleUser in users)
                {
                    // Using AddUsers for each user
                    var response = await AddUsers(singleUser);
                    if (!response.Success)
                    {
                        // Handle specific error for this user
                        throw new Exception(response.Error);
                    }
                }

                return new Response
                {
                    Success = true,
                    Message = $"{users.Count} users have been successfully uploaded to the database."
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Success = false,
                    Error = ex.Message
                };
            }
        }
        private async Task<FileContent> ConvertToFileContent(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return new FileContent
                {
                    FileName = file.FileName,
                    FileData = memoryStream.ToArray()
                };
            }
        }
        private async Task<List<Users>> ProcessCsvFile(FileContent fileContent)
        {
            var users = new List<Users>();

            using (var reader = new StreamReader(new MemoryStream(fileContent.FileData)))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Map CSV columns to Users fields
                csv.Context.RegisterClassMap<UserDetailMap>();

                // Get records from the CSV file
                var records = csv.GetRecords<Users>();
                foreach (var record in records)
                {
                    users.Add(record);
                }
            }

            return users;
        }

        public sealed class UserDetailMap : ClassMap<Users>
        {
            public UserDetailMap()
            {
                Map(m => m.FullName).Name("FullName");
                Map(m => m.MobileNumber).Name("MobileNumber");
                Map(m => m.DateOfBirth)
                    .Name("DateOfBirth")
                    .TypeConverter<CustomDateConverter>(); 
                Map(m => m.Password).Name("Password");
            }
        }
    }
}
public class CustomDateConverter : DefaultTypeConverter
{
    private readonly string[] _dateFormats = { "dd/MM/yyyy", "dd-MM-yy", "MM-dd-yy", "yyyy-MM-dd" };

    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        if (string.IsNullOrWhiteSpace(text))
            return null;

        foreach (var format in _dateFormats)
        {
            if (DateTime.TryParseExact(text, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return date;
            }
        }

        throw new CsvHelperException(row.Context, $"Invalid date format: '{text}' in column '{memberMapData.Member.Name}'");
    }
}

