using Business.Abstract;
using Dto.Account;
using RestSharp;

namespace Business.Concrete
{
    public class AccountApiManager : IAccountApiService
    {
        public async Task<StatusMessage> AddAsync(AccountAdd dtoToAdd)
        {
            var client = new RestClient(ApiConfiguration.BaseUrl);

            var request = new RestRequest($"/account/create-account", Method.POST, DataFormat.Json);
            request.AddObject(dtoToAdd);

            var response = await client.ExecuteAsync(request);

            var statusMessage = new StatusMessage
            {
                Message = response.Content,
                Code = (int)response.StatusCode,
            };

            return statusMessage;
        }

        public async Task<StatusMessage> DeleteAsync(AccountDetail dtoToDelete)
        {
            var client = new RestClient(ApiConfiguration.BaseUrl);

            var request = new RestRequest($"/account/delete-account", Method.POST, DataFormat.Json);
            request.AddObject(dtoToDelete);

            var response = await client.ExecuteAsync(request);

            var statusMessage = new StatusMessage
            {
                Message = response.Content,
                Code = (int)response.StatusCode,
            };

            return statusMessage;
        }

        public async Task<AccountDetail> GetAccountDetailAsync(string hostingDomainName)
        {
            var client = new RestClient(ApiConfiguration.BaseUrl);

            var request = new RestRequest($"/account/get-account", Method.GET, DataFormat.Json);
            request.AddParameter("hostingDomainName", hostingDomainName);

            var accountDetail = await client.ExecuteAsync<AccountDetail>(request);

            return accountDetail.Data;
        }

        public async Task<IEnumerable<string>> GetAllAccountDetailsAsync()
        {
            var client = new RestClient(ApiConfiguration.BaseUrl);

            var request = new RestRequest($"/account/get-all-accounts", Method.GET, DataFormat.Json);    

            var accountDetails = await client.ExecuteAsync<IEnumerable<string>>(request);

            return accountDetails.Data;
        }
    }
}
