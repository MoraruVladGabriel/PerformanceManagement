using System;
using System.Collections.Generic;
using WindowsFormsApp1.domain;

namespace WindowsFormsApp1.repository
{
    public interface ISpectacolRepository : IRepository<int, Spectacol>
    {
        List<Spectacol> FilterByDay(DateTime data);
    }
}