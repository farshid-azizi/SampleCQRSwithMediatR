using MediatR;
using SampleCQRSwithMediatR.Context;

namespace SampleCQRSwithMediatR.PersonFeatures.Commands.Edit
{
    public class EditPersonCommandHandler : IRequestHandler<EditPersonCommandModel, Guid>
    {
        private readonly IApplicationContext _context;

        public EditPersonCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(EditPersonCommandModel request, CancellationToken cancellationToken)
        {
            var person = _context.Persons.Where(a => a.Id == request.Id).FirstOrDefault();

            if (person == null)
            {
                return default;
            }
            else
            {
                person.Name = request.Name;
                person.Family = request.Family;
                person.NationalCode = request.NationalCode;
                person.MobileNumber = request.MobileNumber;
                person.Email = request.Email;

                _context.Persons.Update(person);
                await _context.SaveChangesAsync();
                return person.Id;
            }
        }
    }
}
