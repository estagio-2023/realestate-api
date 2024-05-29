using FluentValidation;
using RealEstateApi.Dto.Request;

namespace RealEstateApi.Validators
{
    public class GetVisitRequestAvailabilityValidator : AbstractValidator<VisitRequestAvailabilityDto>
    {
        public GetVisitRequestAvailabilityValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty()
                .Matches(@"^\d{4}-\d{2}-\d{2}$").WithMessage("Date must be in the format YYYY-MM-DD.");
            RuleFor(x => x.StartTime)
                .NotEmpty()
                .Matches(@"^(?:[01]\d|2[0-3]):(?:[0-5]\d)$").WithMessage("Start time must be in the format HH:MM.");
            RuleFor(x => x.EndTime)
                .NotEmpty()
                .Matches(@"^(?:[01]\d|2[0-3]):(?:[0-5]\d)$").WithMessage("End time must be in the format HH:MM.");
            RuleFor(x => x.RealEstateId)
                .NotEmpty();
            RuleFor(x => x.AgentId)
                .NotEmpty();
        }
    }
}
