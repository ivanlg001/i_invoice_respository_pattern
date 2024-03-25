using I_Invoice_Repository_Pattern.Models;
using I_Invoice_Repository_Pattern.Repositories;

namespace I_Invoice_Repository_Pattern.Handlers
{
    public class DirectoryHandler : IDirectoryHandler
    {
        private readonly IPersonRepository _personRepo;

        public DirectoryHandler(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }
        public IEnumerable<Person> FindPersons()
        {
            return (IEnumerable<Person>)_personRepo.FindAll();
        }

        public Person FindPersonByIdCard(string id)
        {
            return _personRepo.FindOne(id);
        }

        public Person StorePerson(Person person)
        {
            return _personRepo.Insert(person);
        }

        public Person Update(Person person)
        {
            return _personRepo.Update(person);
        }

        public bool DeletePersonByIdCard(string id)
        {
            bool result = false;
            var person = FindPersonByIdCard(id);
            if( person != null)
            {
                result = _personRepo.Delete(person.Id);
            }

            return result;
        }
    }
}
