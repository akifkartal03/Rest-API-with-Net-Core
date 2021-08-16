using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netflixAPI.Domain
{
    public class ProgramTable
    {
        [Key]
        public Guid ProgramID { get; set; }

        public string ProgramName { get; set; }

        public int ProgramType { get; set; }

        public int NumberofEpisode { get; set; }

        public float ProgramLength { get; set; }
    }
}
