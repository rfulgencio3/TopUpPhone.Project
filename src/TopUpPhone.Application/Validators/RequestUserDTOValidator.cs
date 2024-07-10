using FluentValidation;
using TopUpPhone.Application.DTOs;
using TopUpPhone.Core.Domain.Enums;

public class RequestUserDTOValidator : AbstractValidator<RequestUserDTO>
{
    public RequestUserDTOValidator()
    {
        RuleFor(x => x.Balance).GreaterThanOrEqualTo(0).WithMessage("BALANCE_MUST_BE_POSITIVE");
        
        RuleFor(x => x.Status).Must(status => status == Status.Active.ToString().ToLower() || status == Status.Inactive.ToString().ToLower())
                              .WithMessage("STATUS_MUST_BE_EITHER_'active'_OR_'inactive'.");
    }
}
