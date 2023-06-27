using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.ShowFestivalApplicationReviews
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public CreateDto Application { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var festival = await _context.Festivals.FindAsync(request.Application.FestivalId);

                if (festival == null) return null;

                var show = await _context.Shows.SingleOrDefaultAsync(x => x.SerialNumber == request.Application.SerialNumber);
                
                if (show == null) {
                    show = new Show {
                        SerialNumber = request.Application.SerialNumber,
                        Name = request.Application.Name,
                        DirectorName = request.Application.DirectorName,
                        StoryWriterName = request.Application.StoryWriterName,
                        AdditionalInformation = request.Application.AdditionalInformation,
                    };

                    _context.Shows.Add(show);
                }

                var application = new ShowFestivalApplicationReview {
                    Festival = festival,
                    Show = show,
                    Acceptable = false,
                    Reviewed = false
                };

                _context.ShowFestivalApplicationReviews.Add(application);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create application");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}