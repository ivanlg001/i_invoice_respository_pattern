using I_Invoice_Repository_Pattern.Models;

namespace I_Invoice_Repository_Pattern.Handlers
{
    public interface IDirectoryHandler
    {
        IEnumerable<Person> FindPersons();
        Person FindPersonByIdCard(string id);
        Person StorePerson(Person person);
        Person Update(Person person);
        bool DeletePersonByIdCard(string id);
    }
}
