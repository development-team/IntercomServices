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
        public int TicketID { get; set; }
        public string CallerName { get; set; }
        public string Description { get; set; }
        public int AddressID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string StatusReason { get; set; }
        public string StatusID{get; set;}
        public string Assignee { get; set; }
             
    }
    
    public class CreateModel
    {
        [Required]
        [Display(Name = "Coller's name")]
        public string CallerName { get; set; }
        [Required]
        [Display(Name = "Problem")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Address ID")]
        public int AddressID { get; set; }
        [Required]
        [Display(Name = "Street")]
        public string Street { get; set; }
        [Required]
        [Display(Name = "Home")]
        [StringLength(5, ErrorMessage = "Home umber  cannot be longer than 5 characters.")]
        public string Home { get; set; }
        [Required]
        [Display(Name = "Appartment")]
        [StringLength(10, ErrorMessage = "Appartment cannot be longer than 10 characters.")]
        public string Appartment { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }


    
    }
}