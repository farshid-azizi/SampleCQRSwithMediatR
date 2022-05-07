using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleCQRSwithMediatR.Context;
using SampleCQRSwithMediatR.Models;

namespace SampleCQRSwithMediatR.PersonFeatures.Queries.GetPersonsList
{

    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonQueryModel, IEnumerable<Person>>
    {
        private readonly IApplicationContext _context;

        public GetAllPersonsQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> Handle(GetAllPersonQueryModel request, CancellationToken cancellationToken)
        {
            var personList = await _context.Persons.ToListAsync();
            if (personList == null)
            {
                return null;
            }
            return personList.AsReadOnly();
        }
    }
    
}
