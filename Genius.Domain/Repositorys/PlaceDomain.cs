using Genius.Infraestructure;
using Genius.Infraestructure.Models;

namespace Genius.Domain;

public class PlaceDomain:IPlaceDomain
{
    private IPlaceInfraestructure _placeInfraestructure;

    public PlaceDomain(IPlaceInfraestructure placeInfraestructure)
    {
        _placeInfraestructure = placeInfraestructure;
    }
    
    public Task<List<Place>> GetAll()
    {
        return _placeInfraestructure.GetAll();
    }

    public async Task<bool> CreateAsync(Place place)
    {

        return await _placeInfraestructure.CreateAsync(place);
    }

    public async Task<bool> Update(int id, Place input)
    {
        return await _placeInfraestructure.Update(id, input);
    }

    public async Task<bool> Delete(int id)
    {
        return await _placeInfraestructure.Delete(id);
    }
}