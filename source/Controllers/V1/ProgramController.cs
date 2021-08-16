using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using netflixAPI.Contracts.V1;
using netflixAPI.Contracts.V1.Requests;
using netflixAPI.Contracts.V1.Responses;
using netflixAPI.Domain;
using netflixAPI.Extensions;
using netflixAPI.Services;

namespace netflixAPI.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProgramController : Controller
    {
        private readonly IProgramService _programService;

        public ProgramController(IProgramService programService)
        {
            _programService = programService;
        }

        [HttpGet(ApiRoutes.Program.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _programService.GetProgramAsync());
        }

        [HttpPut(ApiRoutes.Program.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid programId, [FromBody] UpdateProgramRequest request)
        {
            /*var userOwnsProgram = await _programService.UserOwnsProgramAsync(programId, HttpContext.GetUserId());

            if (!userOwnsProgram)
            {
                return BadRequest(new {error = "You do not own this Program"});
            }*/

            var Program = await _programService.GetProgramByIdAsync(programId);
            Program.ProgramName = request.ProgramName;
            Program.NumberofEpisode = request.NumberofEpisode;
            Program.ProgramLength = request.ProgramLength;

            var updated = await _programService.UpdateProgramAsync(Program);

            if(updated)
                return Ok(Program);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Program.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid programId)
        {
            /*var userOwnsProgram = await _programService.UserOwnsProgramAsync(ProgramId, HttpContext.GetUserId());

            if (!userOwnsProgram)
            {
                return BadRequest(new {error = "You do not own this Program"});
            }*/
            
            var deleted = await _programService.DeleteProgramAsync(programId);

            if (deleted)
                return NoContent();

            return NotFound();
        }

        [HttpGet(ApiRoutes.Program.Get)]
        public async Task<IActionResult> Get([FromRoute]Guid programId)
        {
            var Program = await _programService.GetProgramByIdAsync(programId);

            if (Program == null)
                return NotFound();

            return Ok(Program);
        }

        [HttpPost(ApiRoutes.Program.Create)]
        public async Task<IActionResult> Create([FromBody] CreateProgramRequest ProgramRequest)
        {
            var newProgramId = Guid.NewGuid();
            var Program = new ProgramTable
            {
                ProgramID = newProgramId,
                ProgramName = ProgramRequest.ProgramName,
                ProgramType = ProgramRequest.ProgramType,
                NumberofEpisode = ProgramRequest.NumberofEpisode,
                ProgramLength = ProgramRequest.ProgramLength
            };
            
            await _programService.CreateProgramAsync(Program);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Program.Get.Replace("{programId}", Program.ProgramID.ToString());

            var response = new CommonResponse {Id = Program.ProgramID};
            return Created(locationUri, response);
        }
    }
}