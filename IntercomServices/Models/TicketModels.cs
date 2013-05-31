using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace iLexStudio.IntercomServices.Models
{
    /// <summary>
    /// all data for tickets
    /// </summary>
    public class TicketModels
    {
        /// <summary>
        /// Status of tickets
        /// </summary>
        public enum TicketStatus
        {
            New=1,
            Checked=2,
            Assigned=4,
            Completed=8,
            Rejected=16,
            Closed=32
        }

        /// <summary>
        /// ticket to the system
        /// </summary>
        public class Ticket
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int ObjectID { get; set; }

           
            public int StreetID { get; set; }
            public string CallerName { get; set; }
            public int TicketType { get; set; }
            public string Description { get; set; }
            public int HomeID { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public int Status { get; set; }
            public string StatusReason { get; set; }
        }
    }

   
}