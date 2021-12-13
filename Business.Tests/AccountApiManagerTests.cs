using Business.Abstract;
using Business.Concrete;
using Dto.Account;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Business.Tests
{
    public class AccountApiManagerTests
    {
        private readonly IAccountApiService _accountApiService;

        public AccountApiManagerTests()
        {
            _accountApiService = new AccountApiManager();

        }


        [Fact]
        public async void GetAllAccountsNotNullResult()
        {
            var account = await _accountApiService.GetAllAccountDetailsAsync();
            Assert.NotNull(account);

        }

        [Fact]
        public async Task GetExactNumberOfAccounts()
        {
            var numberOfAccount = 5;

            var accounts = await _accountApiService.GetAllAccountDetailsAsync();
            Assert.Equal(numberOfAccount, accounts.Count());

        }
        

        [Fact]
        public async void GetAccountTypeConsistentResult()
        {
            var account = await _accountApiService.GetAccountDetailAsync("deneme.com");
            Assert.IsType<AccountDetail>(account);
        }

        [Fact]
        public async void CreatingNewAccountTest()
        {     

            var account = new AccountAdd
            {
                HostingDomainName = "UnitTest.com",
                HostingPackage = "basit-package"
            };

            await _accountApiService.AddAsync(account);

            var createdAccount = await _accountApiService.GetAccountDetailAsync(account.HostingDomainName);
            Assert.Equal(account.HostingDomainName, createdAccount.HostingDomainName);
        }

        [Fact]
        public async void DeletingAccountTest()
        {
            var accountToDelete = new AccountDetail
            {
                HostingDomainName = "UnitTest.com",
                HostingPackage = "basit-package"
            };

            await _accountApiService.DeleteAsync(accountToDelete);

            var accounts = await _accountApiService.GetAllAccountDetailsAsync();

            Assert.DoesNotContain(accountToDelete.HostingDomainName, accounts);
        }
    }
}
