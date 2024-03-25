using I_Invoice_Repository_Pattern.Models;
using I_Invoice_Repository_Pattern.Repositories;

namespace I_Invoice_Repository_Pattern.Handlers
{
    public class SalesHandler : ISalesHandler
    {
        IInvoiceRepository _invoiceRepo;
        public SalesHandler(IInvoiceRepository invoiceRepo)
        {
            _invoiceRepo = invoiceRepo;
        }
        public Invoice FindInvoiceByIdCard(string id)
        {
            return _invoiceRepo.FindOne(id);
        }

        public Invoice StoreInvoice(Invoice invoice)
        {
            invoice.Date = DateTime.Now;
            return _invoiceRepo.Insert(invoice);
        }
    }
}
