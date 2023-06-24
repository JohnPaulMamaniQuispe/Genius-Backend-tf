namespace Genius.Infraestructure;

public interface IOwnerInfraestructure
{
    Task<List<Owner>> GetAll();
    Task<List<Owner>> GetByFirtname(string firtname);
    Owner GetById(int id); 
    //bool Create(string name, int age, string license, string phone);
    Task <Boolean> CreateAsync(Owner input);
    Task <Boolean>Update(int id, Owner input);
    Task <Boolean> Delete(int id);
}