using I_Invoice_Repository_Pattern.Models;

namespace I_Invoice_Repository_Pattern.Repositories
{
    public interface IPersonRepository
    {
        bool Delete(string id);
        IEnumerable<Person> FindAll();
        Person FindOne(string id);
        Person Insert(Person person);
        Person Update(Person person);
    }
}
