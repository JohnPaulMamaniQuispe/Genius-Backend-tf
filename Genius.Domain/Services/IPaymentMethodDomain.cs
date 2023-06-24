using Genius.Infraestructure.Models;

namespace Genius.Domain;

public interface IPaymentMethodDomain
{
    public Task<List<PaymentMethod>> GetAll();
    Task <Boolean>CreateAsync(PaymentMethod paymentMethod);
    Task <Boolean>Update(int id, PaymentMethod input);
    Task<Boolean> Delete(int id);
}