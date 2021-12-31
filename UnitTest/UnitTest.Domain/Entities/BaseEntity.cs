using FluentValidation;
using FluentValidation.Results;
using System;

namespace UnitTest.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
        protected DateTime CreateDate { get;  set; }
        protected DateTime UpdateDate { get;  set; }

        public bool Valid { get; private set; }
        public bool Invalid => !Valid;
        public ValidationResult ValidationResult { get; private set; }

        public bool Validate<TEntity>(TEntity entity, AbstractValidator<TEntity> validator)
        {
            this.ValidationResult = validator.Validate(entity);
            return this.Valid = this.ValidationResult.IsValid;
        }
    }
}
