using Backend.Filters;
using Backend.Models.Dtos;
using Backend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Backend.Controllers
{

    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]

    public class MessageController : ControllerBase
    {

        private readonly MessageRepository _messageRepo;

        public MessageController(MessageRepository messageRepo)
        {
            _messageRepo = messageRepo;
        }


        [HttpPost]
        public async Task<IActionResult> CreateMessage(MessageRequest message)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            await _messageRepo.AddMessage(message);
            return Created("", null);

        }
    }
}
