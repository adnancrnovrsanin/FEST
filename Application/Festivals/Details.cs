using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Festivals
{
    public class Details
    {
        public class Query : IRequest<Result<Festival>> {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Festival>>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Festival>> Handle(Query request, CancellationToken cancellationToken)
            {
                var festival = await _context.Festivals.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (festival == null) return null;

                return Result<Festival>.Success(festival);
            }
        }
    }
}