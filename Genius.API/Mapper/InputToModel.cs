using AutoMapper;
using Genius.API.Input;
using Genius.Infraestructure;
using Genius.Infraestructure.Model;
using Genius.Infraestructure.Models;

namespace Genius.API.Mapper;

public class InputToModel: Profile
{public InputToModel()
    {
        CreateMap<DriverInput, Driver>();
        CreateMap<CarInput, Car>();
        CreateMap<OwnerInput, Owner>();
        CreateMap<UserInput, User>();
        CreateMap<UserLoginInput, User>();
    }
}