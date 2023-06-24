
using AutoMapper;
using Genius.Infraestructure.Models;
using Genius.API.Response;
using Genius.Infraestructure;
using Genius.Infraestructure.Model;

namespace Genius.API.Mapper;

public class ModelToResponse: Profile

{

    public ModelToResponse()
    {
        CreateMap<User, UserResponse> ();
        CreateMap<Car, CarResponse>();
        CreateMap<Driver, DriverResponse>();
        CreateMap<Reservation, ReservationResponse>();
        CreateMap<Parking, ParkingResponse>();
        CreateMap<PaymentMethod, PaymentMethodResponse>();
        CreateMap<Place, PlaceResponse>();
        CreateMap<Owner, OwnerResponse>();
        CreateMap<OwnerType, OwnerTypeResponse >();
        
       
    

    }
}

