using MainAppBackend.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainAppBackend.Application.Dtos.ClientLookup
{
    public class ClientLookupDto : BaseDto
    {
        public string? Code { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; } = null;
        public string? Description { get; set; } = null;
    }
}
