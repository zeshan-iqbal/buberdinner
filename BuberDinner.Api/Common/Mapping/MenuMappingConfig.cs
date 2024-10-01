using BuberDinner.Application.Menus.Commands;
using BuberDinner.Contracts.Menu;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.Entities;

using Mapster;

namespace BuberDinner.Api.Common.Mapping;
public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);


        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString())
            .Map(dest => dest.AverageRating, src => src.AverageRating.Value)
            .Map(dest => dest.HostId, src => src.HostId.Value) // TODOs: This can be done via implicit cast as well
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(x => x.Value.ToString()))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(x => x.Value.ToString()));


        config.NewConfig<MenuSection, MenuResponse.MenuSection>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString());

        config.NewConfig<MenuItem, MenuResponse.MenuSection.MenuSectionItem>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString());

    }
}