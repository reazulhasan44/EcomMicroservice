namespace Ordering.Domain.ValueObjects
{
    public record CustomerId
    {
        public Guid Value { get; }
        private CustomerId(Guid value)
        {
            Value = value;
        }

        /// <summary>   
        /// "of" Static methods belong to the record itself
        /// not to instances of the record 
        /// and are used to create CustomerId
         
        public static CustomerId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("CustomerId cannot be empty.");
            }
            return new CustomerId(value);
        }
    }
}
