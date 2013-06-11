using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iLexStudio.IntercomServices.Models.Tickets
{
    public class CreateModel
    {
        public string BuildingID { get; set; }

        public string CallerName { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
    public class EditModel
    {
        [Editable(false)]
        public int ObjectID { get; set; }
        public string CallerName { get; set; }
        public string Description { get; set; }
        public string BuildingID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string StatusReason { get; set; }
        public TicketStatus Status { get; set; }
        public int Assignee { get; set; }
    }
}