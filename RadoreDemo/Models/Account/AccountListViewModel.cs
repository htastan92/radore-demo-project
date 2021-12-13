using Dto.Account;

namespace RadoreDemo.Models.Account
{
    public class AccountListViewModel
    {
        public IEnumerable<AccountListDetailViewModel> AccountList { get; set; } = new List<AccountListDetailViewModel>();
        public AccountNewViewModel? AccountNewViewModel { get; set; }
    }
}
