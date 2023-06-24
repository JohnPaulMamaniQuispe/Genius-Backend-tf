using Genius.Infraestructure.Models;

namespace Genius.Infraestructure;

public interface IPlaceInfraestructure
{
    Task<List<Place>> GetAll();
    Place GetById(int id);
    Task <Boolean> CreateAsync(Place place);
    Task <Boolean>Update(int id, Place input);
    Task <Boolean> Delete(int id);
}