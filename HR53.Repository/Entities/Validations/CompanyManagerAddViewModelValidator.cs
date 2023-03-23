using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR53.Repository.Entities.Validations
{
    public class CompanyManagerAddViewModelValidator : AbstractValidator<AppUser>
    {
        public CompanyManagerAddViewModelValidator()
        {
            RuleFor(user => user.Firstname)
                                                .NotNull().NotEmpty()
                                                .MaximumLength(50)
                                                .WithMessage("First Name cannot be longer than 50 characters!");



            RuleFor(user => user.MiddleName)
            .MaximumLength(50)
            .WithMessage("Middlename cannot be longer than 50 characters!"); ;



            RuleFor(user => user.LastName)
            .NotNull().NotEmpty()
            .MaximumLength(50)
            .WithMessage("Surname cannot be longer than 50 characters!");



            RuleFor(user => user.SecondSurname)
            .MaximumLength(50)
            .WithMessage("Surname cannot be longer than 50 characters!"); ;



            RuleFor(user => user.Birthdate)
            .LessThan(user => DateTime.Now)
            .WithMessage("Birthdate must be less than current date!");



            RuleFor(user => user.Birthplace)
            .MaximumLength(100).NotNull().NotEmpty()
            .WithMessage("Birthplace must be shorter than 100!");



            RuleFor(user => user.IdentityCardNo)
            .Length(11)
            .WithMessage("Please enter 11 digit Identity Card Number.");



            RuleFor(user => user.EmploymentDate)
            .LessThan(user => DateTime.Now)
            .WithMessage("Employement Date must be less than current date!"); ;



            RuleFor(user => user.Profession)
            .MaximumLength(100)
            .WithMessage("Proffession cannot be longer than 100 characters!");



            RuleFor(user => user.Department)
            .MaximumLength(400)
            .WithMessage("Department cannot be longer than 400 characters!");



            RuleFor(user => user.Email)
            .EmailAddress()
            .WithMessage("Email Adress is not valid! \n ex: johndoe@example.com");



            RuleFor(user => user.Adress)
            .MaximumLength(400)
            .WithMessage("Adress cannot be longer than 400 character!");



            RuleFor(user => user.PhoneNumber)
            .MaximumLength(16)
            .WithMessage("Phone Number cannot be longer than 16 characters!");



            RuleFor(user => user.Picture);
        }

    }
}
