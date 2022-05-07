using MediatR;
using SampleCQRSwithMediatR.Context;
using SampleCQRSwithMediatR.Models;

namespace SampleCQRSwithMediatR.PersonFeatures.Queries.FindPersonById
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQueryModel, Person>
    {
        private readonly IApplicationContext _context;

        public GetPersonByIdQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Person> Handle(GetPersonByIdQueryModel request, CancellationToken cancellationToken)
        {
            var person = _context.Persons.Where(a => a.Id == request.Id).FirstOrDefault();
            if (person == null) return null;
            return person;
        }
    }

}
