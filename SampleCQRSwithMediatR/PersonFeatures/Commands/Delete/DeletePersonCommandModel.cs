using MediatR;

namespace SampleCQRSwithMediatR.PersonFeatures.Commands.Delete
{
    public class DeletePersonCommandModel : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}

