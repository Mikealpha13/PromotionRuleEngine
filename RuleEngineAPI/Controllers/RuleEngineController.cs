using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RuleEngineAPI.Application.Commands.Promotion;
using RuleEngineAPI.Application.ViewModels.Movies;
using RuleEngineAPI.Infrastructure.Middleware;
using System;
using System.Threading.Tasks;

namespace RuleEngineAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ServiceFilter(typeof(RuleEngineExceptionHandler))]
    [ApiController]
    public class RuleEngineController : ControllerBase
    {
        private readonly IMediator _mediatR;
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public RuleEngineController(IMediator mediator)
        {
            _mediatR = mediator ?? throw new ArgumentNullException(nameof(mediator));
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("Promotions")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ApplicablePromotion([FromBody]PromotionRequestViewModel request)
        {
            request.RequestId = Guid.NewGuid().ToString();
            return Ok(await _mediatR.Send(new PromotionRuleCommand(request)));
        }


    }
}
