using System;
using System.Collections.Generic;
using System.Text;
using Modular.Monolithic.Architecture.Helper.Domain.Core;

namespace Modular.Monolithic.Architecture.Helper.Domain.Errors
{
    /// <summary>
    /// Represents a concrete domain error.
    /// </summary>
    public sealed class Error : ValueObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="code">The error code.</param>
        /// <param name="message">The error message.</param>
        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string Message { get; }

        public override string ToString() =>   $"{Code}: {Message}";

        /// <inheritdoc />
        protected override IEnumerable<object> GetValues()
        {
            yield return Code;
            yield return Message;
        }
    }
}
