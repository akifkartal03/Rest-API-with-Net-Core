using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netflixAPI.Contracts.V1.Requests
{
    public class CreateProgramRequest
    {
        public string ProgramName { get; set; }

        public int ProgramType { get; set; }

        public int NumberofEpisode { get; set; }

        public float ProgramLength { get; set; }
    }
}
