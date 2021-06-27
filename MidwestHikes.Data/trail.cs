using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidwestHikes.Data
{
    public class trail
    {
        [Key]
        public int TrailId { get; set; }
        [ForeignKey("Park")]
        public int ParkId { get; set; }
        public virtual park Park { get; set; }
        public string TrailName { get; set; }
        public string TrailDesc { get; set; }
        
    }
}
