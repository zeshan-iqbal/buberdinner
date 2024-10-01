using BuberDinner.Application.Menus.Commands;
using BuberDinner.Contracts.Menu;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenuController: ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public MenuController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(CreateMenuRequest createMenuRequest, string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((createMenuRequest, hostId));
        var result = await _mediator.Send(command);

        return result.Match(
            menu => Ok(_mapper.Map<MenuResponse>(menu)),
            erros => Problem(erros));
    }    
}