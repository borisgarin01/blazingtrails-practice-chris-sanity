﻿using Domain;
using FluentValidation;

namespace Shared;

public class TrailValidator : AbstractValidator<TrailDto>
{
    public TrailValidator()
    {
        RuleFor(x => x.Name).NotEmpty()
            .WithMessage("Please enter a name");
        RuleFor(x => x.Description).NotEmpty()
            .WithMessage("Please enter a description");
        RuleFor(x => x.Location).NotEmpty()
            .WithMessage("Please enter a location");
        RuleFor(x => x.Length).GreaterThan(0)
            .WithMessage("Please enter a length");
        RuleFor(x => x.Route).NotEmpty()
            .WithMessage("Please add a route instruction");
        RuleForEach(x => x.Route).SetValidator(new RouteInstructionValidator());
    }
}
