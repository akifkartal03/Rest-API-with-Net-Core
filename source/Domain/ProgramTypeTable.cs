using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace netflixAPI.Domain
{
    public class ProgramTypeTable
    {
        [Key]
        public Guid PrgTypeId { get; set; }

        public Guid PrgId { get; set; }

        [ForeignKey(nameof(PrgId))]
        public ProgramTable Program { get; set; }

        public Guid TypeID { get; set; }

        [ForeignKey(nameof(TypeID))]
        public Types Type { get; set; }
    }
}
