using I_Invoice_Repository_Pattern.Models;

namespace I_Invoice_Repository_Pattern.Handlers
{
    public interface ISalesHandler
    {
        Invoice FindInvoiceByIdCard(string id);
        Invoice StoreInvoice(Invoice invoice);
    }
}
