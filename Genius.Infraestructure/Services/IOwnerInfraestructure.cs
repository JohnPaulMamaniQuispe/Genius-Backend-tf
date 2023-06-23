namespace Genius.Infraestructure;

public interface IOwnerInfraestructure
{
    Task<List<Owner>> GetAll();
    Task<List<Owner>> GetByfirtname(string firtname);
    Owner GetById(int id); 
    //bool Create(string name, int age, string license, string phone);
    Task <bool> CreateAsync(Owner input);
    Task <bool>Update(int id, Owner input);
    Task <bool> Delete(int id);
}