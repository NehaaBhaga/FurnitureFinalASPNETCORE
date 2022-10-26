


using APICapstoneProject.Data;
using APICapstoneProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;



namespace APICapstoneProject.Controllers

{

    [ApiController]

    [Route("api/[controller]")]

    public class OrderRequestsController : Controller

    {

        private readonly OrderRequestDBContext orderRequestDBContext;



        public OrderRequestsController(OrderRequestDBContext orderRequestDBContext)

        {

            this.orderRequestDBContext = orderRequestDBContext;

        }



        // Get all Registrations  

        [HttpGet]

        public async Task<IActionResult> GetAllOrderRequests()

        {

            var orderRequests = await orderRequestDBContext.OrderRequests.ToListAsync();

            return Ok(orderRequests);

        }



        // Get Single Registration 

        [HttpGet]

        [Route("{uid}")]

        [ActionName("GetOrderRequest")]

        public async Task<IActionResult> GetOrderRequest([FromRoute] string uid)

        {

            var orderRequests = await orderRequestDBContext.OrderRequests.FirstOrDefaultAsync(x => x.Uid == uid);

            if (orderRequests != null)

            {

                return Ok(orderRequests);

            }

            return NotFound("Not Found");

        }



        //Add Registration 



        [HttpPost]



        public async Task<IActionResult> AddOrderRequest([FromBody] OrderRequest orderRequest)

        {

           // orderRequest.Uid = Guid.NewGuid().ToString();





            await orderRequestDBContext.OrderRequests.AddAsync(orderRequest);

            await orderRequestDBContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderRequest), new { uid = orderRequest.Uid }, orderRequest);

        }





        //update Registration 

        [HttpPut]

        [Route("{uid}")]

        public async Task<IActionResult> UpdateOrderRequest(string uid, [FromBody] OrderRequest orderRequest)

        {

            var ExistingOrderRequest = await orderRequestDBContext.OrderRequests.FirstOrDefaultAsync(x => x.Uid == uid);



            if (ExistingOrderRequest != null)

            {

                ExistingOrderRequest.Uid = orderRequest.Uid;

                ExistingOrderRequest.Email = orderRequest.Email;

                ExistingOrderRequest.FurnitureNeeded = orderRequest.FurnitureNeeded;

                ExistingOrderRequest.EquipmentNeeded = orderRequest.EquipmentNeeded;

                ExistingOrderRequest.ShippingAddress = orderRequest.ShippingAddress;


                ExistingOrderRequest.OrderStatus = orderRequest.OrderStatus;



                await orderRequestDBContext.SaveChangesAsync();

                return Ok(ExistingOrderRequest);



            }

            return NotFound("Not Found");

        }







        //delete Registration 

        [HttpDelete]

        [Route("{uid}")]

        public async Task<IActionResult> DeleteOrderRequest(string uid)

        {

            var ExistingOrderRequest = await orderRequestDBContext.OrderRequests.FirstOrDefaultAsync(x => x.Uid == uid);



            if (ExistingOrderRequest != null)

            {

                orderRequestDBContext.Remove(ExistingOrderRequest);

                await orderRequestDBContext.SaveChangesAsync();

                return Ok(ExistingOrderRequest);



            }

            return NotFound("Not Found");

        }

    }

}

