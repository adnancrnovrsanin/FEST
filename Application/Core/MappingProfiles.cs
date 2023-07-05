using System;
using System.Collections.Generic;
using System.Globalization;
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
            CreateMap<ActorShowRoleAudition, ActorShowRoleAudition>();
            CreateMap<ActorShowRoleAudition, ActorShowRoleAuditionDto>()
                .ForMember(d => d.AuditionId, o => o.MapFrom(s => s.Audition.Id))
                .ForMember(d => d.ActorId, o => o.MapFrom(s => s.Actor.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Actor.Name))
                .ForMember(d => d.Surname, o => o.MapFrom(s => s.Actor.Surname))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Actor.Email))
                .ForMember(d => d.VideoURL, o => o.MapFrom(s => s.Audition.VideoURL))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Audition.Description))
                .ForMember(d => d.ShowRoleId, o => o.MapFrom(s => s.ShowRole.Id))
                .ForMember(d => d.RoleName, o => o.MapFrom(s => s.ShowRole.Name))
                .ForMember(d => d.ShowId, o => o.MapFrom(s => s.ShowRole.Show.Id))
                .ForMember(d => d.ShowName, o => o.MapFrom(s => s.ShowRole.Show.Name))
                .ForMember(d => d.AverageReview, o => o.MapFrom(s => s.Audition.Reviews.Count == 0 ? 0 : s.Audition.Reviews.Average(r => r.Review)));
            CreateMap<Audition, Audition>();
            CreateMap<Schedule, Schedule>();
            CreateMap<ScheduleDto, ScheduleDto>();
            CreateMap<Schedule, ScheduleDto>()
                .ForMember(sd => sd.FestivalName, o => o.MapFrom(s => s.Festival.Name))
                .ForMember(sd => sd.TheatreName, o => o.MapFrom(s => s.TheatreShow.Theatre.Name))
                .ForMember(sd => sd.ShowName, o => o.MapFrom(s => s.TheatreShow.Show.Name))
                .ForMember(sd => sd.FestivalId, o => o.MapFrom(s => s.Festival.Id))
                .ForMember(sd => sd.TheatreId, o => o.MapFrom(s => s.TheatreShow.Theatre.Id))
                .ForMember(sd => sd.ShowId, o => o.MapFrom(s => s.TheatreShow.Show.Id))
                .ForMember(sd => sd.TimeOfPlay, o => o.MapFrom(s => s.TimeOfPlay.GetValueOrDefault().ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture)));
            CreateMap<ScheduleDto, Schedule>()
                .ForMember(s => s.TimeOfPlay, o => o.MapFrom(sd => DateTime.Parse(sd.TimeOfPlay, null, System.Globalization.DateTimeStyles.RoundtripKind)));
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
            CreateMap<AppUser, ActorProfileDto>()
                .ForMember(d => d.ProfilePicture, o => o.MapFrom(s => s.Photos.FirstOrDefault(p => p.IsMain)))
                .ForMember(d => d.Photos, o => o.MapFrom(s => s.Photos.Where(p => !p.IsMain)))
                .ForMember(d => d.AuditionsReviewed, o => o.MapFrom(s => s.Auditions.Where(a => a.Audition.Reviews.Count > 2)))
                .ForMember(d => d.AuditionsNotReviewed, o => o.MapFrom(s => s.Auditions.Where(a => a.Audition.Reviews.Count < 3)));
            CreateMap<AppUser, ReviewerProfileDto>()
                .ForMember(d => d.ProfilePicture, o => o.MapFrom(s => s.Photos.FirstOrDefault(p => p.IsMain)));
            CreateMap<ActorShowRole, ActorShowRoleDto>();
            CreateMap<AuditionReview, AuditionsReviewDto>();
            CreateMap<ActorShowRole, ActorShowRoleDto>();   
            CreateMap<ShowFestivalApplication, ShowFestivalApplicationDto>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Show.Name))
                .ForMember(d => d.FestivalId, o => o.MapFrom(s => s.Festival.Id))
                .ForMember(d => d.TheatreId, o => o.MapFrom(s => s.Theatre.Id))
                .ForMember(d => d.SerialNumber, o => o.MapFrom(s => s.Show.SerialNumber))
                .ForMember(d => d.DirectorName, o => o.MapFrom(s => s.Show.DirectorName))
                .ForMember(d => d.StoryWriterName, o => o.MapFrom(s => s.Show.StoryWriterName))
                .ForMember(d => d.LengthOfPlay, o => o.MapFrom(s => s.Show.LengthOfPlay))
                .ForMember(d => d.AdditionalInformation, o => o.MapFrom(s => s.Show.AdditionalInformation));

        }
    }
}