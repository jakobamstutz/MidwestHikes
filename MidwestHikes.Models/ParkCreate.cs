using MidwestHikes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidwestHikes.Models
{
    public class ParkCreate
    {
        //[ForeignKey("State")]
        public int StateId { get; set; }
        public string ParkName { get; set; }
        public string ParkDesc { get; set; }

        // public List<int> ListOfStates { get; set; }

        // public virtual List<trail> Trail { get; set; } = new List<trail>();

    }
}
