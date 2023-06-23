
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
        CreateMap<Driver, DriverResponse>();
        CreateMap<Car, CarResponse>();
        CreateMap<Owner, OwnerResponse>();
        CreateMap<User, UserResponse> ();

    }
}

