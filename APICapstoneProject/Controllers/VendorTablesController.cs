
using APICapstoneProject.Data;
using APICapstoneProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;



namespace APICapstoneProject.Controllers

{

    [ApiController]

    [Route("api/[controller]")]

    public class VendorTablesController : Controller

    {

        private readonly VendorTableDBContext vendorTableDBContext;



        public VendorTablesController(VendorTableDBContext vendorTableDBContext)

        {

            this.vendorTableDBContext = vendorTableDBContext;

        }



        // Get all Vendor Tables 

        [HttpGet]

        public async Task<IActionResult> GetAllVendorTables()

        {

            var vendorTables = await vendorTableDBContext.VendorTables.ToListAsync();

            return Ok(vendorTables);

        }



        // Get Single Vendor Table 

        [HttpGet]

        [Route("{uid}")]

        [ActionName("GetVendorTable")]

        public async Task<IActionResult> GetVendorTable([FromRoute] string uid)

        {

            var vendorTables = await vendorTableDBContext.VendorTables.FirstOrDefaultAsync(x => x.Uid == uid);

            if (vendorTables != null)

            {

                return Ok(vendorTables);

            }

            return NotFound("Not Found");

        }



        //Add Vendor Table



        [HttpPost]



        public async Task<IActionResult> AddVendorTable([FromBody] VendorTable vendorTable)

        {

            //vendorTable.Uid = Guid.NewGuid().ToString();





            await vendorTableDBContext.VendorTables.AddAsync(vendorTable);

            await vendorTableDBContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVendorTable), new { uid = vendorTable.Uid }, vendorTable);

        }





        //update Vendor Table 

        [HttpPut]

        [Route("{uid}")]

        public async Task<IActionResult> UpdateVendorTable(string uid, [FromBody] VendorTable vendorTable)

        {

            var ExistingVendorTable = await vendorTableDBContext.VendorTables.FirstOrDefaultAsync(x => x.Uid == uid);



            if (ExistingVendorTable != null)

            {

                ExistingVendorTable.Uid = vendorTable.Uid;

                ExistingVendorTable.Email = vendorTable.Email;

                ExistingVendorTable.FurnitureNeeded = vendorTable.FurnitureNeeded;

                ExistingVendorTable.EquipmentNeeded= vendorTable.EquipmentNeeded;

                ExistingVendorTable.ShippingAddress = vendorTable.ShippingAddress;

                ExistingVendorTable.OrderStatus = vendorTable.OrderStatus;

                await vendorTableDBContext.SaveChangesAsync();

                return Ok(ExistingVendorTable);



            }

            return NotFound("Not Found");

        }







        //delete Vendor Table

        [HttpDelete]

        [Route("{uid}")]

        public async Task<IActionResult> DeleteVendorTable(string uid)

        {

            var ExistingVendorTable = await vendorTableDBContext.VendorTables.FirstOrDefaultAsync(x => x.Uid == uid);



            if (ExistingVendorTable != null)

            {

                vendorTableDBContext.Remove(ExistingVendorTable);

                await vendorTableDBContext.SaveChangesAsync();

                return Ok(ExistingVendorTable);



            }

            return NotFound("Not Found");

        }

    }

}