using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidwestHikes.Data
{
    public class state
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }

        public virtual List<park> Park { get; set; }
    }
}
