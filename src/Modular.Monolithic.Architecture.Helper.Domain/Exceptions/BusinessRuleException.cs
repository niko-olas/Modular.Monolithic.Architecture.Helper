using Modular.Monolithic.Architecture.Helper.Domain.BusinessRules;

namespace Modular.Monolithic.Architecture.Helper.Domain.Exceptions;

public class BusinessRuleValidationException : DomainException
{
    public IBusinessRule BrokenRule { get; }

    public BusinessRuleValidationException(IBusinessRule brokenRule)
        : base(brokenRule.Error)
    {
        BrokenRule = brokenRule;
    }

    public override string ToString() => $"{BrokenRule.GetType().FullName}: {BrokenRule.Error}";
}
