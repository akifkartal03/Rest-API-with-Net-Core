using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace netflixAPI.Domain
{
    public class UserProgramTable
    {
        [Key]
        public Guid UserPrgID { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public Guid PrgID { get; set; }

        [ForeignKey(nameof(PrgID))]
        public ProgramTable Prg { get; set; }
        public DateTime LastWatchedTime { get; set; }

        public double WatchedTime { get; set; }
        public int LastEpisode { get; set; }

        public double UserGrade { get; set; }



    }
}
