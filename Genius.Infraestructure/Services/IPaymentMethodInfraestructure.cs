using Genius.Infraestructure.Models;

namespace Genius.Infraestructure;

public interface IPaymentMethodInfraestructure
{
    Task<List<PaymentMethod>> GetAll();
    
    PaymentMethod GetById(int id); 
    //bool Create(string name, int age, string license, string phone);
    Task <Boolean> CreateAsync(PaymentMethod paymentMethod);
    Task <Boolean>Update(int id, PaymentMethod input);
    Task <Boolean> Delete(int id);
}