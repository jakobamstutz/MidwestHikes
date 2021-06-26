using MidwestHikes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidwestHikes.Models
{
    public class ParkDetail
    {
        public int ParkId { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }
        public string ParkName { get; set; }
        public string ParkDesc { get; set; }

        public virtual List<trail> Trail { get; set; } 
    }
}
