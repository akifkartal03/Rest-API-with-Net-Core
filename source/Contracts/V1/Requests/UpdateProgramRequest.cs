using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netflixAPI.Contracts.V1.Requests
{
    public class UpdateProgramRequest
    {
        public string ProgramName { get; set; }
        public int NumberofEpisode { get; set; }

        public float ProgramLength { get; set; }
    }
}
