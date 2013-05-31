using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace iLexStudio.IntercomServices.Models
{
    /// <summary>
    /// context of database
    /// </summary>
    public class IntercomContext : DbContext
    {
        /// <summary>
        /// all tickets in database
        /// </summary>
        public DbSet<TicketModels.Ticket> Tickets { get; set; }

        /// <summary>
        /// User profiles
        /// </summary>
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}