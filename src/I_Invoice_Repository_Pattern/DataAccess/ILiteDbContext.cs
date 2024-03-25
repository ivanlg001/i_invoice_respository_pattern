using LiteDB;

namespace I_Invoice_Repository_Pattern.DataAccess
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; }
    }
}
