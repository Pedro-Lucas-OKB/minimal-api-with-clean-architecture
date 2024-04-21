using CleanArchitecture.Application.Shared.UserCQRS;
using CleanArchitecture.Application.UseCases.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<UserResponse>> Create(UserRequest.CreateUserRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<UserResponse>>> GetAll(CancellationToken cancellationToken) 
    {
        var response = await _mediator.Send(new UserRequest.GetAllUsersRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserResponse>> Update(Guid id, UserRequest.UpdateUserRequest request, CancellationToken cancellationToken)
    {
        if(id != request.Id) return BadRequest();

        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
