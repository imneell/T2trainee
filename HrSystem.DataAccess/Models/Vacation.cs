using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class Vacation
    {

        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public bool IsDraft { get; set; }

        [ForeignKey("Id")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
