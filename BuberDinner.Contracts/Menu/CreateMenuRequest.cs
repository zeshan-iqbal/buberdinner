namespace BuberDinner.Contracts.Menu;

public record CreateMenuRequest(
    string Name,
    string Description,
    List<CreateMenuRequest.MenuSections> Sections)
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
}