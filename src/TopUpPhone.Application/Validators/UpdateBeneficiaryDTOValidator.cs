using FluentValidation;
using TopUpPhone.Application.DTOs;
using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Application.Validators;
public class UpdateBeneficiaryDTOValidator : AbstractValidator<UpdateBeneficiaryDTO>
{
    public UpdateBeneficiaryDTOValidator()
    {
        RuleFor(x => x.Nickname)
            .NotEmpty().WithMessage("NICKNAME_IS_REQUIRED")
            .MaximumLength(20).WithMessage("The Nickname field must not exceed {MaxLength} characters.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("PHONENUMBER_IS_REQUIRED");

        RuleFor(x => x.Status).Must(status => status == Status.Active.ToString().ToLower() || status == Status.Inactive.ToString().ToLower())
                              .WithMessage("STATUS_MUST_BE_EITHER_'active'_OR_'inactive'.");
    }
}
