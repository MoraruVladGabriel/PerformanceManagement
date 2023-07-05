using System.Collections.Generic;
using WindowsFormsApp1.domain;

namespace WindowsFormsApp1.repository
{
    public interface IArtistRepository : IRepository<int,Artist>
    {
        List<Artist> FilterByTip(string tip);
    }
}