using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR53.Repository.Entities.Validations
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(company => company.CompanyName)
 .NotNull().MaximumLength(100).WithMessage("Company Name cannot be longer than 100 characters!");



            RuleFor(company => company.Title)
            .NotNull().MaximumLength(250).WithMessage("Title cannot be longer than 250 characters!");





            RuleFor(company => company.MersisNumber)
            .Length(16).Must((company, t) => company.MersisNumber.StartsWith("0")).WithMessage("Mersis Number must start with 0");




            RuleFor(company => company.TaxOffice)
            .MaximumLength(400).WithMessage("Tax Office cannot be longer than 400 characters!");



            RuleFor(company => company.TaxNumber)
                .GreaterThan(999999999);



            RuleFor(company => company.Logo);



            RuleFor(company => company.Phone)
            .MaximumLength(15).NotNull();



            RuleFor(company => company.Email)
            .EmailAddress().NotNull();



            RuleFor(company => company.Adress)
            .MaximumLength(400).WithMessage("Adress cannot be longer than 400 characters.");



            RuleFor(company => company.TotalEmployeeNumber)
            .NotNull().GreaterThanOrEqualTo(1);



            RuleFor(company => company.FoundationYear).NotNull();



            RuleFor(company => company.ContractStartDate).NotNull();



            RuleFor(company => company.ContractFinishDate).NotNull();



            RuleFor(company => company.IsActive).NotNull();
        }
    }
}
