using I_Invoice_Repository_Pattern.DataAccess;
using I_Invoice_Repository_Pattern.Models;
using LiteDB;

namespace I_Invoice_Repository_Pattern.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public string Error { get; private set; }

        private LiteDatabase _liteDb;

        public InvoiceRepository(ILiteDbContext liteDbContext)
        {
            _liteDb = liteDbContext.Database;
        }

        public bool Delete(string id)
        {
            try
            {
                bool success = false;

                var col = _liteDb.GetCollection<Invoice>("Invoice");
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

        public IEnumerable<Invoice> FindAll()
        {
            List<Invoice> list = new List<Invoice>();

            try
            {
                var col = _liteDb.GetCollection<Invoice>("Invoice");
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

        public Invoice FindOne(string id)
        {
            Invoice item;
            try
            {
                var col = _liteDb.GetCollection<Invoice>("Invoice");
                item = col.Find(i => i.Id == id).SingleOrDefault();

                Error = "";
                return item;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        public Invoice Insert(Invoice Invoice)
        {
            try
            {
                var col = _liteDb.GetCollection<Invoice>("Invoice");
                col.Insert(Invoice);

                Error = "";

                return Invoice;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        public Invoice Update(Invoice Invoice)
        {
            try
            {
                bool success = false;

                var col = _liteDb.GetCollection<Invoice>("Invoice");
                success = col.Update(Invoice);


                Error = "";

                return success == true ? Invoice : null;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }
    }
}
