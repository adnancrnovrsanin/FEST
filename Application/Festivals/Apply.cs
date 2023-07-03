using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Domain;
using Domain.ModelDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Festivals
{
    public class Apply
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ShowFestivalApplicationDto FestivalApplication { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _context = context;
                _userAccessor = userAccessor;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var manager = await _context.Users.Include(u => u.ManagedTheatre).SingleOrDefaultAsync(u => u.Email == _userAccessor.GetEmail());

                if (manager == null) return null;

                if (manager.Role != Role.THEATRE_MANAGER || manager.ManagedTheatre == null) return Result<Unit>.Failure("Only theatre manager can register for festival");

                var theatre = await _context.Theatres.SingleOrDefaultAsync(t => t.Id == manager.ManagedTheatre.Id);

                if (theatre == null) return null;

                var festival = await _context.Festivals.FindAsync(request.FestivalApplication.FestivalId);

                if (festival == null) return null;

                var show = new Show {
                    SerialNumber = request.FestivalApplication.SerialNumber,
                    Name = request.FestivalApplication.Name,
                    DirectorName = request.FestivalApplication.DirectorName,
                    StoryWriterName = request.FestivalApplication.StoryWriterName,
                    LengthOfPlay = request.FestivalApplication.LengthOfPlay,
                    AdditionalInformation = request.FestivalApplication.AdditionalInformation,
                };

                var showFestivalApplication = new ShowFestivalApplication {
                    Show = show,
                    Festival = festival,
                    Theatre = theatre,
                    NumberOfActors = request.FestivalApplication.NumberOfActors
                };

                show.Applications.Add(showFestivalApplication);
                _context.Shows.Add(show);
                _context.ShowFestivalApplications.Add(showFestivalApplication);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to apply for festival");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}