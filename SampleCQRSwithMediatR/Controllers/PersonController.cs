using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleCQRSwithMediatR.PersonFeatures.Commands.Add;
using SampleCQRSwithMediatR.PersonFeatures.Commands.Delete;
using SampleCQRSwithMediatR.PersonFeatures.Commands.Edit;
using SampleCQRSwithMediatR.PersonFeatures.Queries.FindPersonById;
using SampleCQRSwithMediatR.PersonFeatures.Queries.GetPersonsList;

namespace SampleCQRSwithMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator mediator;

        public PersonController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Creates a New Person.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(AddPersonCommandModel command)
        {
            return Ok(await mediator.Send(command));
        }
        /// <summary>
        /// Gets all Persons.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllPersonQueryModel()));
        }
        /// <summary>
        /// Gets Person Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await mediator.Send(new GetPersonByIdQueryModel { Id = id }));
        }
        /// <summary>
        /// Deletes Person Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await mediator.Send(new DeletePersonCommandModel { Id = id }));
        }
        /// <summary>
        /// Updates the Person Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, EditPersonCommandModel command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await mediator.Send(command));
        }
    }
}
