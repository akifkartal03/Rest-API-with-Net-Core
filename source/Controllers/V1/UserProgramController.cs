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
    public class UserProgramController : Controller
    {
        private readonly IUserProgramService _userProgramService;

        public UserProgramController(IUserProgramService userProgramService)
        {
            _userProgramService = userProgramService;
        }

        [HttpGet(ApiRoutes.UserProgram.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userProgramService.GetUserProgramAsync());
        }

        [HttpPut(ApiRoutes.UserProgram.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid userProgramId, [FromBody] CreateUserPrgRequest request)
        {
            /*var userOwnsProgram = await _programService.UserOwnsProgramAsync(programId, HttpContext.GetUserId());

            if (!userOwnsProgram)
            {
                return BadRequest(new {error = "You do not own this Program"});
            }*/

            var userPrg1 = await _userProgramService.GetUserProgramByIdAsync(userProgramId);
            userPrg1.PrgID = request.PrgID;
            userPrg1.LastWatchedTime = request.LastWatchedTime;
            userPrg1.WatchedTime = request.WatchedTime;
            userPrg1.LastEpisode = request.LastEpisode;
            userPrg1.UserGrade = request.UserGrade;

        var updated = await _userProgramService.UpdateUserProgramAsync(userPrg1);

            if(updated)
                return Ok(userPrg1);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.UserProgram.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid userProgramId)
        {
            /*var userOwnsProgram = await _programService.UserOwnsProgramAsync(ProgramId, HttpContext.GetUserId());

            if (!userOwnsProgram)
            {
                return BadRequest(new {error = "You do not own this Program"});
            }*/
            
            var deleted = await _userProgramService.DeleteUserProgramAsync(userProgramId);

            if (deleted)
                return NoContent();

            return NotFound();
        }

        [HttpGet(ApiRoutes.UserProgram.Get)]
        public async Task<IActionResult> Get([FromRoute]Guid userProgramId)
        {
            var userPrg1 = await _userProgramService.GetUserProgramByIdAsync(userProgramId);

            if (userPrg1 == null)
                return NotFound();

            return Ok(userPrg1);
        }

        [HttpPost(ApiRoutes.UserProgram.Create)]
        public async Task<IActionResult> Create([FromBody] CreateUserPrgRequest userProgramRequest)
        {
            var newId = Guid.NewGuid();
            var userPrg1 = new UserProgramTable
            {
                UserPrgID = newId,
                UserId = HttpContext.GetUserId(),
                PrgID = userProgramRequest.PrgID,
                LastWatchedTime = userProgramRequest.LastWatchedTime,
                WatchedTime = userProgramRequest.WatchedTime,
                LastEpisode = userProgramRequest.LastEpisode,
                UserGrade = userProgramRequest.UserGrade

            };
            
            await _userProgramService.CreateUserProgramAsync(userPrg1);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.UserProgram.Get.Replace("{userprgId}", userPrg1.UserPrgID.ToString());

            var response = new CommonResponse { Id = userPrg1.UserPrgID};
            return Created(locationUri, response);
        }
    }
}