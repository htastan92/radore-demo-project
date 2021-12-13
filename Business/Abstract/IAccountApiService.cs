using Dto.Account;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAccountApiService
    {
        Task<AccountDetail> GetAccountDetailAsync(string hostingDomainName);
        Task<IEnumerable<string>> GetAllAccountDetailsAsync();
        Task<StatusMessage> AddAsync(AccountAdd dtoToAdd);
        Task<StatusMessage> DeleteAsync(AccountDetail dtoToDelete);
    }
}
