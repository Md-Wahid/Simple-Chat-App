using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Controllers.DTOs;
using Api.services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _chatService;
        public ChatController(ChatService chatService)
        {
            _chatService = chatService;            
        }

        [HttpPost("register-user")]
        public IActionResult RegisterUser(UserDto userDto)
        {
            if(_chatService.AddUsertoList(userDto.Name)){
                // 204 status code
                return NoContent();
            }

            return BadRequest("This name is taken please choose another name.");
        }
    }
}