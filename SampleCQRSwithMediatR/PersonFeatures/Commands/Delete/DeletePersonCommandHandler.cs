using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleCQRSwithMediatR.Context;
using SampleCQRSwithMediatR.PersonFeatures.Commands.Add;

namespace SampleCQRSwithMediatR.PersonFeatures.Commands.Delete
{
 
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommandModel, Guid>
    {
        private readonly IApplicationContext _context;

        public DeletePersonCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeletePersonCommandModel request, CancellationToken cancellationToken)
        {
            var person = await _context.Persons.Where(c => c.Id == request.Id).FirstOrDefaultAsync();
            if (person == null) return default;
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return person.Id;
        }
    }
}
