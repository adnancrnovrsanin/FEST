using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain.ModelDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Schedules
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ScheduleDto Schedule { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IUserAccessor userAccessor, IMapper mapper)
            {
                _context = context;
                _userAccessor = userAccessor;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var manager = await _context.Users.SingleOrDefaultAsync(x => x.Email == _userAccessor.GetEmail());

                if (manager == null) return null;

                var schedule = await _context.Schedules.Include(s => s.TheatreShow).ThenInclude(ts => ts.Theatre).SingleOrDefaultAsync(x => x.Id == request.Schedule.Id);

                if (schedule == null) return null;

                // if (schedule.TheatreShow.Theatre.ManagerId != manager.Id) return Result<Unit>.Failure("You are not authorized to edit this schedule.");

                _mapper.Map(request.Schedule, schedule);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to edit schedule.");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}