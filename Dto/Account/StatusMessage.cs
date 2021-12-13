using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Account
{
    public record StatusMessage
    {
        public int Code { get; set; }
        public string? Message { get; set; }
    }
}
