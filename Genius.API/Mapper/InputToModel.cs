using AutoMapper;
using Genius.API.Input;
using Genius.Infraestructure;
using Genius.Infraestructure.Model;
using Genius.Infraestructure.Models;

namespace Genius.API.Mapper;

public class InputToModel: Profile
{public InputToModel()
    {
        CreateMap<UserInput, User>();
        CreateMap<CarInput, Car>();
        CreateMap<DriverInput, Driver>();
        CreateMap<ReservationInput,Reservation>();
        CreateMap<ParkingInput, Parking>();
        CreateMap<PaymentMethodInput, PaymentMethod>();
        CreateMap<OwnerInput, Owner>();
        CreateMap<PlaceInput, Place>();
        CreateMap<OwnerTypeInput, OwnerType>();
        CreateMap<UserLoginInput, User>();
        
    }
}