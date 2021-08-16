using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netflixAPI.Contracts.V1.Requests
{
    public class CreateUserPrgRequest
    {
       
        public Guid PrgID { get; set; }

        public DateTime LastWatchedTime { get; set; }

        public double WatchedTime { get; set; }
        public int LastEpisode { get; set; }

        public double UserGrade { get; set; }

    }
}
