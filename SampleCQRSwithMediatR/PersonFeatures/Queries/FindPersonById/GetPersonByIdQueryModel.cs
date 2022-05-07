using MediatR;
using SampleCQRSwithMediatR.Models;

namespace SampleCQRSwithMediatR.PersonFeatures.Queries.FindPersonById
{
    public class GetPersonByIdQueryModel:IRequest<Person>
    {
        public Guid Id { get; set; }
    }
}



