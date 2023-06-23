using Genius.Infraestructure.Models;
namespace Genius.Domain;

public interface IDriverDomain
{
    public Task<List<Driver>> GetAll();
    
    //bool Create(string name, int age, string license, string phone);
   
    
    Task <Boolean>CreateAsync(Driver driver);
    Task <Boolean>Update(int id, Driver driver);
    Task<Boolean> Delete(int id);
}