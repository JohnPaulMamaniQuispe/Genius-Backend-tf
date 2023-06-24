using Genius.Infraestructure;
using Genius.Infraestructure.Models;

namespace Genius.Domain;

public class PaymentMethodDomain:IPaymentMethodDomain
{
    private IPaymentMethodInfraestructure _paymentMethodInfraestructure;

    public PaymentMethodDomain(IPaymentMethodInfraestructure paymentMethodInfraestructure)
    {
        _paymentMethodInfraestructure = paymentMethodInfraestructure;
    }
    
    public Task<List<PaymentMethod>> GetAll()
    {
        return _paymentMethodInfraestructure.GetAll();
    }

    public async Task<bool> CreateAsync(PaymentMethod paymentMethod)
    {
        return await _paymentMethodInfraestructure.CreateAsync(paymentMethod);
    }

    public async Task<bool> Update(int id, PaymentMethod input)
    {
        return await _paymentMethodInfraestructure.Update(id ,input);
    }

    public async Task<bool> Delete(int id)
    {
        return await _paymentMethodInfraestructure.Delete(id);
    }
}