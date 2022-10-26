using APICapstoneProject.Data;
using APICapstoneProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace APICapstoneProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationsController : Controller
    {

        private readonly RegistrationsDbContext registrationDbContext;



        public RegistrationsController(RegistrationsDbContext registrationDbContext)
        {
            this.registrationDbContext = registrationDbContext;
        }


        // Get all Registrations
        [HttpGet]
        public async Task<IActionResult> GetAllRegistrations()
        {
            var registrations = await registrationDbContext.Registrations.ToListAsync();
            return Ok(registrations);
        }



        // Get Single Registration
        [HttpGet]
        [Route("{uid}")]
        [ActionName("GetRegistration")]
        public async Task<IActionResult> GetRegistration([FromRoute] string uid)
        {
            var registration = await registrationDbContext.Registrations.FirstOrDefaultAsync(x => x.Uid == uid);
            if (registration != null)
            {
                return Ok(registration);
            }
            return NotFound("Not Found");
        }


        //Add Registration


        [HttpPost]

        public async Task<IActionResult> AddRegistration([FromBody] Registration registration)
        {
            //registration.Uid = Guid.NewGuid().ToString();




            await registrationDbContext.Registrations.AddAsync(registration);
            await registrationDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRegistration), new { uid = registration.Uid }, registration);
        }


        //update Registration
        [HttpPut]
        [Route("{uid}")]
        public async Task<IActionResult> UpdateRegistration(string uid, [FromBody] Registration registration)
        {
            var ExistingRegistration = await registrationDbContext.Registrations.FirstOrDefaultAsync(x => x.Uid == uid);



            if (ExistingRegistration != null)
            {
                ExistingRegistration.Email = registration.Email;
                ExistingRegistration.Password = registration.Password;
                ExistingRegistration.FirstName = registration.FirstName;
                ExistingRegistration.LastName = registration.LastName;
                ExistingRegistration.Address = registration.Address;
                ExistingRegistration.Role = registration.Role;

                await registrationDbContext.SaveChangesAsync();
                return Ok(ExistingRegistration);



            }
            return NotFound("Not Found");
        }

        //delete Registration
        [HttpDelete]
        [Route("{uid}")]
        public async Task<IActionResult> DeleteRegistration(string uid)
        {
            var ExistingRegistration = await registrationDbContext.Registrations.FirstOrDefaultAsync(x => x.Uid == uid);



            if (ExistingRegistration != null)
            {
                registrationDbContext.Remove(ExistingRegistration);
                await registrationDbContext.SaveChangesAsync();
                return Ok(ExistingRegistration);



            }
            return NotFound("Not Found");
        }
    }
}









    

