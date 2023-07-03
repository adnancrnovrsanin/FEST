using Application.Core;
using AutoMapper;
using Domain.ModelDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class EditTheatreManager
    {
        public class Command : IRequest<Result<Unit>>
        {
            public TheatreManagerProfileDto TheatreManager { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var profile = await _context.Users.Include(p=>p.UserName).SingleOrDefaultAsync(x => x.Surname == request.TheatreManager.Surname);
                if (profile == null) return null;
                _mapper.Map(request.TheatreManager, profile);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update profile");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
