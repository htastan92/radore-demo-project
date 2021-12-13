using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Account
{
    public record AccountDetail
    {
        public string? Message { get; set; }
        public int? IncomingConnections { get; set; }
        public int? CpuLoad { get; set; }
        public int? RamMax { get; set; }
        public int? RamUsage { get; set; }
        public string? HostingDomainName { get; set; }
        public string? HostingPackage { get; set; }
        
    }
}
