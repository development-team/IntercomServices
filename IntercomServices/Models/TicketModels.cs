using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iLexStudio.IntercomServices.Models
{
    public class CreateModel
    {
        public string BuildingID { get; set; }

        public string CallerName { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}