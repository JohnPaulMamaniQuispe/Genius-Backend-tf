using Genius.Infraestructure.Models;

namespace Genius.Infraestructure;

public interface ICarInfraestructure
{
    Task <List<Car>> GetAll();
    Task< List<Car>> GetByName(string name);
    Car GetById(int id); 
    //bool Create(string name, int age, string license, string phone);
    Task<bool> Create(Car input);  // Task -> <representa una operacion Asincrona 
    bool Update(int id, Car input);
    bool Delete(int id);
    
}