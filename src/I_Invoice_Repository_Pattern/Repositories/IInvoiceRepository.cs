using I_Invoice_Repository_Pattern.Models;

namespace I_Invoice_Repository_Pattern.Repositories
{
    public interface IInvoiceRepository
    {
        bool Delete(string id);
        IEnumerable<Invoice> FindAll();
        Invoice FindOne(string id);
        Invoice Insert(Invoice person);
        Invoice Update(Invoice person);
    }
}
