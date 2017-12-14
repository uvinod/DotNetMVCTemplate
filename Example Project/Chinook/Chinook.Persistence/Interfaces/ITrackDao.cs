using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Chinook.Domain;

namespace Chinook.Persistence.Interfaces
{
    public interface ITrackDao : IEntityDao<Track, int>
    {
    }
}
