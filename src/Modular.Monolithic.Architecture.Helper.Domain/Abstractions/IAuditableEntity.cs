using System;
using System.Collections.Generic;
using System.Text;

namespace Modular.Monolithic.Architecture.Helper.Domain.Abstractions
{
    /// <summary>
    /// Represents the marker interface for auditable entities.
    /// </summary>
    public interface IAuditableEntity
    {
        /// <summary>
        /// Gets the created on date and time in UTC format.
        /// </summary>
        DateTime CreatedOn { get; }

        /// <summary>
        /// Gets the modified on date and time in UTC format.
        /// </summary>
        DateTime? ModifiedOn { get; }
    }
}
