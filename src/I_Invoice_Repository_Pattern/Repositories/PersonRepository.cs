using I_Invoice_Repository_Pattern.DataAccess;
using I_Invoice_Repository_Pattern.Models;
using LiteDB;

namespace I_Invoice_Repository_Pattern.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public string Error { get; private set; }

        private LiteDatabase _liteDb;

        public PersonRepository(ILiteDbContext liteDbContext)
        {
            _liteDb = liteDbContext.Database;
        }

        public bool Delete(string id)
        {
            try
            {
                bool success = false;

                var col = _liteDb.GetCollection<Person>("Person");
                success = col.Delete(id);

                Error = "";

                return success;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public IEnumerable<Person> FindAll()
        {
            List<Person> list = new List<Person>();

            try
            {
                var col = _liteDb.GetCollection<Person>("Person");
                list = col.FindAll().ToList();
                
                Error = "";
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
            return list;
        }

        public Person FindOne(string id)
        {
            Person item;
            try
            {
                var col = _liteDb.GetCollection<Person>("Person");
                item = col.Find(i => i.IdCard == id).SingleOrDefault();
                
                Error = "";
                return item;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        public Person Insert(Person person)
        {
            try
            {
                person.Id = Guid.NewGuid().ToString().Replace("-", "");

                var col = _liteDb.GetCollection<Person>("Person");
                col.Insert(person);

                Error = "";

                return person;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        public Person Update(Person person)
        {
            try
            {
                bool success = false;
                                
                var col = _liteDb.GetCollection<Person>("Person");
                success = col.Update(person);
                

                Error = "";

                return success == true ? person : null;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }
    }
}
