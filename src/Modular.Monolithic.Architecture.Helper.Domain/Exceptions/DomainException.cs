using System;
using Modular.Monolithic.Architecture.Helper.Domain.Errors;

namespace Modular.Monolithic.Architecture.Helper.Domain.Exceptions
{
    /// <summary>
    /// Represents an exception that occurred in the domain.
    /// </summary>
    public class DomainException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainException"/> class.
        /// </summary>
        /// <param name="error">The error containing the information about what happened.</param>
        public DomainException(Error error)
            : base(error.Message)
            => Error = error;

        /// <summary>
        /// Gets the error.
        /// </summary>
        public Error Error { get; }
    }
}
