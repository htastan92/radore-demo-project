namespace Dto.Account
{
    public record AccountAdd
    {
        public string? HostingDomainName { get; set; }
        public string? HostingPackage { get; set; }
    }
}
