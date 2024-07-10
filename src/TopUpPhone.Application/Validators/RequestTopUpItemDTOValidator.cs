using FluentValidation;
using TopUpPhone.Application.DTOs;
using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.Application.Validators;
public class RequestTopUpItemDTOValidator : AbstractValidator<RequestTopUpItemDTO>
{
    public RequestTopUpItemDTOValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("DESCRIPTION_IS_REQUIRED");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("AMOUNT_MUST_BE_POSITIVE");

        RuleFor(x => x.TransactionFee)
            .GreaterThanOrEqualTo(0).WithMessage("TRANSACTION_FEE_MUST_BE_POSITIVE");

        RuleFor(x => x.Status).Must(status => status == Status.Active.ToString().ToLower() || status == Status.Inactive.ToString().ToLower())
                              .WithMessage("STATUS_MUST_BE_EITHER_'active'_OR_'inactive'.");
    }
}
