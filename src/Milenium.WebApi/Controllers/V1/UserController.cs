using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Milenium.Application.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;

namespace Milenium.WebApi.Controllers.V1
{

    //[ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}")]
    [Route("api/")]
    public class UserController : ApiBaseController
    {
        private List<UserDto> _users = new List<UserDto> { 
            new UserDto { Id = "16ba4580-6bc8-4d90-9332-764fda20d17a", UserName = "user1", Password = "password1", Email = "email1" },
            new UserDto { Id = "16ba4580-6bc8-4d90-9332-764fda20d15a", UserName = "user2", Password = "password2", Email = "email2" },

        };
        //private readonly IMediator _mediator;
        private ILogger<UserController> _logger;
        public UserController( ILogger<UserController> logger) //IMediator mediator,
        {
           // _mediator = mediator;
            _logger = logger;
        }

        //[HttpPost("create")]
        //public IActionResult Create(
        //    [FromQuery, RequiredUserName] string userName,
        //    [FromQuery, RequiredPassword] string password,
        //    [FromQuery, RequiredEmail] string email,
        //    CancellationToken cancellationToken)
        //{
        //    //var response = await _mediator.Send(new (new 
        //    //{
        //    //    UserName = userName,
        //    //    Password = password,
        //    //    Email = email
        //    //}), cancellationToken);


        //    return CreatedAtActionResult( _users);
        //}

        [HttpGet("users")]
        public IActionResult GetAll()
        {

            //var response = await _mediator.Send(new GetUserQuery()
            //}), cancellationToken);

            _logger.LogInformation("Found {Count} users", _users.Count);

            return Ok(_users);
        }

        [HttpGet("user")]
        public IActionResult GetById(string id)
        {
            var user = _users.Where(user => user.Id.Equals(id,StringComparison.OrdinalIgnoreCase));

            if(user == null)
                return NotFound();
            //var response = await _mediator.Send(new GetUserQuery()
            //}), cancellationToken);

            _logger.LogInformation("Found user", user);

            return Ok(user);
        }

        [HttpPost("create")]
        public IActionResult Create(
            [FromQuery, Required] string userName,
            [FromQuery, Required] string password,
            [FromQuery, Required] string email,
            CancellationToken cancellationToken)
        {
            //var response = await _mediator.Send(new (new 
            //{
            //    UserName = userName,
            //    Password = password,
            //    Email = email
            //}), cancellationToken);
            var guid = Guid.NewGuid().ToString();

            var newUser = new UserDto { UserName = userName, Password = password, Email = email , Id = guid};
            _users.Add(newUser);


            return Ok(newUser);// should be Created
        }
    }
}
