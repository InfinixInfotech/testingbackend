
using Models.Common;

namespace Repository.Common
{
    public interface IIdentifierService
    {
        Task<long> GetCountAsync();
        Task InsertIdentifierAsync(InfinixId identifier);
    }
}
