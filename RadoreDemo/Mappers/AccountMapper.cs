using RadoreDemo.Models.Account;

namespace RadoreDemo.Mappers
{
    public static class AccountMapper
    {
        public static AccountListViewModel List(IEnumerable<string> domainNames)
        {
            var accountList = domainNames.Select(domainName => new AccountListDetailViewModel
            {
                DomainName = domainName
            }
            ).ToList();

            return new AccountListViewModel { AccountList = accountList };
        }
    }
}
