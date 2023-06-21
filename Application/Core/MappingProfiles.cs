using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using Domain.ModelDTOs;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Festival, Festival>();
            CreateMap<AppUser, AppUser>();
            CreateMap<AppUser, UserDto>();
            CreateMap<UserDto, AppUser>();
            CreateMap<ActorAudition, ActorAudition>();
            CreateMap<Audition, Audition>();
            CreateMap<Schedule, Schedule>();
            CreateMap<Show, Show>();
            CreateMap<Theatre, Theatre>();
            CreateMap<Festival, FestivalDto>()
                .ForMember(d => d.StartDate, o => o.MapFrom(s => s.StartDate.ToUniversalTime()))
                .ForMember(d => d.EndDate, o => o.MapFrom(s => s.EndDate.ToUniversalTime()));
            CreateMap<Theatre, TheatreDto>();
            CreateMap<TheatreDto, Theatre>();
            CreateMap<FestivalDto, Festival>()
                .ForMember(d => d.StartDate, o => o.MapFrom(s => DateTime.Parse(s.StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind)))
                .ForMember(d => d.EndDate, o => o.MapFrom(s => DateTime.Parse(s.EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind)));

        }
    }
}