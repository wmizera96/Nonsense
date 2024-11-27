using Microsoft.AspNetCore.Mvc;
using Nonsense.Tasks.BusinessLogic;
using Nonsense.Tasks.BusinessLogic.Requests;

namespace Nonsense.Tasks.API.Controllers;

public class TasksController : BaseApiController
{
    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await Mediator.Send(new GetNonsenseTaskQuery(id)));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        return Ok(await Mediator.Send(new ListNonsenseTasksQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateNonsenseTaskCommand request)
    {
        return Ok(await Mediator.Send(request));
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateNonsenseTaskCommand request)
    {
        request.Id = id;
        return Ok(await Mediator.Send(request));
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await Mediator.Send(new DeleteNonsenseTaskCommand(id)));
    }
}