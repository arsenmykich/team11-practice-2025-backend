using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business_Logic_Layer.DTOs;
using Data_Access_Layer.Entities;

namespace Business_Logic_Layer.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieDTO, Movie>();
            CreateMap<Actor, ActorDTO>();
            CreateMap<ActorDTO, Actor>();
            CreateMap<Session, SessionDTO>();
            CreateMap<SessionDTO, Session>();
            CreateMap<Booking, BookingDTO>();
            CreateMap<BookingDTO, Booking>();
            CreateMap<SalesStatistics, SalesStatisticsDTO>();
            CreateMap<SalesStatisticsDTO, SalesStatistics>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Director, DirectorDTO>();
            CreateMap<DirectorDTO, Director>();
            CreateMap<Genre, GenreDTO>();
            CreateMap<GenreDTO, Genre>();
            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>();
        }
    }    
}
