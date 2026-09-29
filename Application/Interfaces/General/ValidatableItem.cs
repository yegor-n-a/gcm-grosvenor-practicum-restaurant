using Application.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Application.Interfaces.General
{
    public class ValidatableItem<TError> : IValidatableItem<TError>
        where TError : class
    {
        protected List<TError> Failures { get; }

        public virtual bool IsValid => Errors.IsNullOrEmpty();
        public virtual IReadOnlyCollection<TError> Errors => Failures;

        public virtual void AddError(TError error)
        {
            if (error == null)
            {
                return;
            }

            Failures.Add(error);
        }

        public virtual void AddError(IEnumerable<TError> errors)
        {
            errors = errors?
                .Where(error => error != null);

            if (errors.IsNullOrEmpty())
            {
                return;
            }

            foreach (var error in errors)
            {
                Failures.Add(error);
            }
        }

        private List<TError> CreateFailures(IEnumerable<TError> errors)
        {
            errors = errors?
                .Where(error => error != null);

            return errors.IsNullOrEmpty()
                ? new List<TError>()
                : new List<TError>(errors);
        }

        public ValidatableItem(TError error)
            : this(error != null ? new[] { error } : Enumerable.Empty<TError>())
        { }

        public ValidatableItem(IEnumerable<TError> errors)
        {
            Failures = CreateFailures(errors);
        }
    }
}
