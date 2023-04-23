﻿using BuildingEnergyCalculator.Entities;
using FluentValidation;

namespace BuildingEnergyCalculator.Models.Validators
{
    public class RegisterUserDtoValidator: AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(EnergyCalculatorDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password).MinimumLength(6);
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password);

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(x => x.Email == value);
                    if (emailInUse)
                        context.AddFailure("Email", "That email is taken");

                });

        }
    }
}
