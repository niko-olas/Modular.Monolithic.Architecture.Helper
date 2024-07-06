using Modular.Monolithic.Architecture.Helper.Domain.Errors;

namespace Modular.Monolithic.Architecture.Helper.Domain.BusinessRules;

public interface IBusinessRule
{
    bool IsFail();
    Error Error { get; }
}
