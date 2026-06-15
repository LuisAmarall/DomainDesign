namespace DomainDesign.Exceptions
{
    public class InvalidValueObjectException : DomainException
    {
        public InvalidValueObjectException(string invalidValueObject) : base(invalidValueObject) { }
    }
}