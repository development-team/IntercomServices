using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;

namespace iLexStudio.IntercomServices.Models
{
    [Table("Ticket")]
    public class Ticket
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ObjectID { get; set; }
        public string CallerName { get; set; }
        public string Description { get; set; }
        public string BuildingID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string StatusReason { get; set; }
        public string Status { get; set; }
        public string Assignee { get; set; }
    }
    
    public class CreateModel
    {
        [Required]
        [Display(Name = "Your name")]
        public string CallerName { get; set; }
        [Required]
        [Display(Name = "Problem")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string BuildingID { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}