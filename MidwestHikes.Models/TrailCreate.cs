using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidwestHikes.Models
{
    public class TrailCreate
    {
        [ForeignKey("Park")]
        public int ParkId { get; set; }
        public string TrailName { get; set; }
        public string TrailDesc { get; set; }
    }
}
