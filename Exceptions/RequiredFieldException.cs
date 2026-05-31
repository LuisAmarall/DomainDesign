namespace DomainDesign.Exceptions
{
    public class RequiredFieldException : DomainException
    {
        public RequiredFieldException(string fieldName) : base(fieldName) { }
    }
}