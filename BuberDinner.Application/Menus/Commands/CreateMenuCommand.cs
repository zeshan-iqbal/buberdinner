using System.Runtime.InteropServices.Marshalling;

using BuberDinner.Application.Common.Contracts.Persistence;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands;

public record CreateMenuCommand(
    string Name,
    string Description,
    string HostId,
    List<CreateMenuCommand.MenuSections> Sections): IRequest<ErrorOr<Menu>>
{
    public record MenuSections(
        string Name,
        string Description,
        List<MenuSections.MenuSectionItems> Items)
    {
        public record MenuSectionItems(
            string Name,
            string Description);
    }

    
    private class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;

        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // create menu
            var menu = Menu.Create(
                Domain.HostAggregate.ValueObjects.HostId.Create(command.HostId),
                command.Name,
                command.Description,
                command.Sections
                    .ConvertAll(x => MenuSection.Create(
                        x.Name,
                        x.Description,
                        x.Items.ConvertAll(menuItem => MenuItem.Create(
                            menuItem.Name,
                            menuItem.Description)))));
            // persist menu
            _menuRepository.Add(menu);
            // return menu
            return menu;
        }
    }
}