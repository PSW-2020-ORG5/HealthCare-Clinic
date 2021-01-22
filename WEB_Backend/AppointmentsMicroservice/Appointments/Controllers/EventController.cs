using Appointments.Model;
using Appointments.Repository;
using Appointments.Services;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.Controllers
{

    [Produces("application/json")]
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventStoreService eventStore;

        public EventController(AppointmentsDbContext dbContext)
        {
            this.eventStore = new EventStoreService(dbContext);
        }

        [HttpPost]
        public IActionResult Save([FromBody] SchedulingEvent schedulingEvent)
        {
            eventStore.AddEvent(schedulingEvent);
            return Ok();
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(eventStore.GetAll());
        }

        [HttpGet]
        public IActionResult GetStatisticDTO()
        {
            return Ok(eventStore.eventsDTO);
        }


    }
}
