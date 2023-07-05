using System.Collections.Generic;
using WindowsFormsApp1.domain;

namespace WindowsFormsApp1.repository
{
    public interface ICasierRepository : IRepository<int, Casier>
    {
        List<Casier> FilterByOficiu(string oficiuCautat);
        Casier GetCasierByEmail(string emailCautat);
    }
}