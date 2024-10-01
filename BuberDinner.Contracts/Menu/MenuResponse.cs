namespace BuberDinner.Contracts.Menu;

public record MenuResponse(
    string Id,
    string Name,
    string Description,
    float? AverageRating,
    List<MenuResponse.MenuSection> Sections,
    string HostId,
    List<string> DinnerIds,
    List<string> MenuReviewIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime)
{
    public record MenuSection(
        string Id,
        string Name,
        string Description,
        List<MenuSection.MenuSectionItem> Items)
    {
        public record MenuSectionItem(
            string Id,
            string Name,
            string Description);
    }
}