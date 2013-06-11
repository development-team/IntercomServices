using System.Data.Entity;

namespace iLexStudio.IntercomServices.Models.Users
{
    /// <summary>
    /// context of database
    /// </summary>
    public class LoginContexts : DbContext
       
    {
     

        public LoginContexts() : base ("DefaultConnection") {

        }

        /// <summary>
        /// User profiles
        /// </summary>
        public DbSet<UserProfile> UserProfiles { get; set; }
    
    }
}