using Genius.Infraestructure.Context;
using Genius.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Genius.Infraestructure;

public class PaymentMethodInfraestructure:IPaymentMethodInfraestructure
{
    private GeniusDBContext _geniusDbContext;

    public PaymentMethodInfraestructure(GeniusDBContext geniusDbContext)
    {
        _geniusDbContext = geniusDbContext;
    }
    
    public async Task<List<PaymentMethod>> GetAll()
    {
        return await _geniusDbContext.PaymentMethods.Where(paymentMethod=> paymentMethod.IsActive).ToListAsync(); 
    }
    
    
    public PaymentMethod GetById(int id)
    {
        return _geniusDbContext.PaymentMethods.Single(paymentMethod=> paymentMethod.IsActive && paymentMethod.Id ==id); 
    }

    public async Task<bool> CreateAsync(PaymentMethod paymentMethod)
    {
        try
        {
            paymentMethod.IsActive = true;
            paymentMethod.DateCreated = DateTime.Now;
            await _geniusDbContext.PaymentMethods.AddAsync(paymentMethod);
            await _geniusDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            throw;
            return false;
        }
    }

    public async Task<bool> Update(int id, PaymentMethod input)
    {
        try
        {
            var paymentMethod = _geniusDbContext.PaymentMethods.Find(id); // var son procesados antes de iniciar codigo 
            paymentMethod.TypePayement = input.TypePayement;
            paymentMethod.NamePayement = input.NamePayement;
            paymentMethod.CodePayement = input.CodePayement;
            paymentMethod.DateUpdated = DateTime.Now;
            await _geniusDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            return false;
        }
    }

    public async Task<bool> Delete(int id)
    {
        var paymentMethod = _geniusDbContext.PaymentMethods.Find(id); //obtengo con id
        paymentMethod.IsActive = false;
        _geniusDbContext.PaymentMethods.Remove(paymentMethod);
        _geniusDbContext.PaymentMethods.Update(paymentMethod);
        await _geniusDbContext.SaveChangesAsync();
        return true;
    }
}