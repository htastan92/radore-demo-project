namespace Dto.Account
{
    public  record AccountList
    {
        public IList<AccountDetail> AccountDetailList { get; set; } = new List<AccountDetail>();
    }
}
