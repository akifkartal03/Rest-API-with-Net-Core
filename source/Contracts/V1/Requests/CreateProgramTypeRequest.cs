using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netflixAPI.Contracts.V1.Requests
{
    public class CreateProgramTypeRequest
    {
        public Guid PrgID { get; set; }

        public Guid TypeId { get; set; }

    }
}
