using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupAPIProject.Models.Location;

namespace GroupAPIProject.Services.Location
{
    public interface ILocationService
    {
        Task<bool> CreateLocationAsync(LocationCreate request);
        Task<bool> RemoveLocationByIdAsync(int LocationId);
        Task<IEnumerable<LocationDetail>> GetLocationListAsync();

        Task<bool> UpdateLocationByIdAsync(int locationId,LocationUpdate update);
    }
}