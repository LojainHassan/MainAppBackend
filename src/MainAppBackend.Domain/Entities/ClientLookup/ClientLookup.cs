using MainAppBackend.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MainAppBackend.Domain.Entities.ClientLookup
{
    [Table("ClientLookup")]
    public class ClientLookup : AuditableEntity
    {
        /// <summary>
        /// The unique code for the status.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// The status name in Arabic.
        /// </summary>
        public string? NameAr { get; set; }

        /// <summary>
        /// The status name in English.
        /// </summary>
        public string? NameEn { get; set; }
    }
}
