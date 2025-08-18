using FluentValidation;

namespace InsuranceApi.Core.Models.Validators
{
    public class SimulationFilterValidator : AbstractValidator<SimulationFilterModel>
    {
        public SimulationFilterValidator()
        {
             RuleFor(x => x.FlexRateMixId)
            .NotNull()
            .WithMessage("FlexRateMixId is obrigatorio.");

             RuleFor(x => x.StartOfTerm)
            .NotNull()
            .WithMessage("FlexRateMixId is required.");

             RuleFor(x => x.StartOfTerm)
            .NotNull()
            .WithMessage("FlexRateMixId is required.");

             RuleFor(x => x.SimulationFlexRateValue)
            .NotNull()
            .WithMessage("SimulationFlexRateValue is required.");

             RuleFor(x => x.SimulationInsuredAmountValue)
            .NotNull()
            .WithMessage("SimulationInsuredAmountValue is required.");

             RuleFor(x => x.SimulationPremiumValue)
            .NotNull()
            .WithMessage("SimulationPremiumValue is required.");

             RuleFor(x => x.SimulationComissionPercentage)
            .NotNull()
            .WithMessage("SimulationComissionPercentage is required.");

             RuleFor(x => x.SimulationComissionValue)
            .NotNull()
            .WithMessage("SimulationComissionValue is required.");

        }
    }
}
