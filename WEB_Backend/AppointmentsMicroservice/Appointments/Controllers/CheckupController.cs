using Appointments.Repository;
using Microsoft.AspNetCore.Mvc;
using Appointments.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Appointments.Model;

namespace Appointments.Controllers
{
    [Produces("application/json")]
    [Route("api/checkups")]
    [ApiController]
    public class TermsController : ControllerBase
    {
        private readonly CheckupService checkupsService;

        public TermsController(AppointmentsDbContext dBContext)
        {
            this.checkupsService = new CheckupService(dBContext);
        }
        public IActionResult GetAll()
        {
            return Ok(checkupsService.getAllCheckups());
        }

        [HttpPost("freeCheckups")]
        public IActionResult GetFreeCheckupsForDoctor([FromBody] DoctorCheckupDTO dto)
        {
            return Ok(checkupsService.FreeCheckupsForDoctorOnDate(dto, dto.CheckupStartTime));
        }

        [HttpGet("patientCheckups/{id}")]
        public IActionResult GetPatientCheckups(int id)
        {
            return Ok(checkupsService.GetAllCheckupsForPatient(id));
        }

        [HttpPost("schedule")]
        public IActionResult ScheduleCheckup([FromBody] DoctorCheckupDTO dto)
        {
            return Ok(checkupsService.ScheduleCheckup(dto));
        }
        [HttpDelete("cancel/{id}")]
        public IActionResult DeleteById(int id)
        {
            return Ok(checkupsService.CancelCheckup(id));
        }

    }
}
