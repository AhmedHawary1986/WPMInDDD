using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WPM.Management.API.Application;

namespace WPM.Management.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManagementController(ManagementApplicationService managementApplicationService,ICommandHandler<SetWeightCommand> commandHandler) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post(CreatePetCommand command)
        {
            await managementApplicationService.Handle(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(SetWeightCommand command)
        {
            await commandHandler.Handle(command);
            return Ok();
        }
    }
}
