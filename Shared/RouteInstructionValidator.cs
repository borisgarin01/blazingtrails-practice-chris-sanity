using Domain;
using FluentValidation;

namespace Shared;

public class RouteInstructionValidator : AbstractValidator<TrailDto.RouteInstruction>
{
    public RouteInstructionValidator()
    {
        RuleFor(x => x.Stage).GreaterThan(0)
            .WithMessage("Please enter a stage");
        RuleFor(x => x.Description).NotEmpty()
            .WithMessage("Please enter a description");
    }
}
