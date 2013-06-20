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
    [Table("Address")]
    public class Address
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AddressID { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string Appartment { get; set; }
    
        public Address(string street, string home, string appartment){
            AddressID = 0;
            Street = street;
            Home = home;
            Appartment = appartment;

        }
        // paramless costuctor
        public Address()
        {
        }
    }



}