using System.Collections.Generic;
using WindowsFormsApp1.domain;

namespace WindowsFormsApp1.repository
{
    public interface ITransactionRepository : IRepository<int, Transaction>
    {
        List<Transaction> FilterByCasier(Casier casierCautat);
        List<Transaction> FilterBySpectacol(Spectacol spectacolCautat);
    }
}