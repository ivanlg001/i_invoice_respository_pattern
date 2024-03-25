namespace I_Invoice_Repository_Pattern.Models
{
    public class Person : Base
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public string IdCard { get; set; }
    }
}
