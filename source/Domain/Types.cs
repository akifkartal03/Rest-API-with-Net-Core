using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netflixAPI.Domain
{
    public class Types
    {
        [Key]
        public Guid TypeID { get; set; }

        public string TypeName { get; set; }
    }
}
