using FluentValidation;

namespace BuberDinner.Application.Menus.Commands;

public sealed class CreateMenuCommandValidator: AbstractValidator<CreateMenuCommand>
{
    public CreateMenuCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Sections).NotEmpty();

        RuleForEach(x => x.Sections)
            .NotNull()
            .ChildRules(section => 
            {
                section.RuleFor(x => x.Name).NotEmpty();
                section.RuleFor(x => x.Description).NotEmpty();
                section.RuleFor(x => x.Items).NotEmpty();

                section.RuleForEach(x => x.Items)
                    .ChildRules(menuItem => 
                    {
                        menuItem.RuleFor(x => x.Name).NotEmpty();
                        menuItem.RuleFor(x => x.Description).NotEmpty();
                    });
            });
    }
}