using BuberDinner.Application.Authentication.Commands;
using BuberDinner.Application.Authentication.Queries;
using BuberDinner.Contracts.Authentication;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        this._mediator = mediator;
        this._mapper = mapper;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query =  _mapper.Map<LoginQuery>(request);

        var result = await _mediator.Send(query);

        return result.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterReuest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        
        var result = await _mediator.Send(command);

        return result.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
}