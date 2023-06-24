using Genius.Infraestructure.Models;

namespace Genius.Domain;

public interface IPlaceDomain
{
    public Task<List<Place>> GetAll();
    Task <Boolean>CreateAsync(Place place);
    Task <Boolean>Update(int id, Place input);
    Task<Boolean> Delete(int id);
}