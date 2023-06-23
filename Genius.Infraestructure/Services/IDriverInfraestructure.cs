using Genius.Infraestructure.Models;

namespace Genius.Infraestructure;

public interface IDriverInfraestructure
{
    Task<List<Driver>> GetAll();
    Task<List<Driver>> GetByName(string name);
    Driver GetById(int id); 
    //bool Create(string name, int age, string license, string phone);
    Task <Boolean> CreateAsync(Driver driver);
    Task <Boolean>Update(int id, Driver driver);
    Task <Boolean> Delete(int id);
    
}