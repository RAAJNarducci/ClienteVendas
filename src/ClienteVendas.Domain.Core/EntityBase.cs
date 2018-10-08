using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Domain.Core
{
    public abstract class EntityBase<T> : AbstractValidator<T> where T : EntityBase<T>
    {
        protected EntityBase()
        {
            ValidationResult = new ValidationResult();
        }

        public int Id { get; set; }
        public ValidationResult ValidationResult { get; protected set; }

        public abstract bool IsValid();
    }
}
