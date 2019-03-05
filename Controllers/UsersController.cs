using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Form3Api.Services;
using Form3Api.Entities;
using Form3Api.Models;
using AutoMapper;

namespace Form3Api.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRespository) {
            _userRepository = userRespository;           
        }

        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            //return _userRepository.Get().ToList();
            var usersFromRepo = _userRepository.Get();
            var users = Mapper.Map<IEnumerable<UserDto>>(usersFromRepo);
            return new JsonResult(users);
        }

        // GET api/users/{id}
        [HttpGet("{id:length(24)}", Name = "Getuser")]
        public ActionResult<User> Get(string id)
        {
            var user = _userRepository.Get(id);
            if (user == null) return NotFound();
            return user;
        }

        // POST api/users
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]        
        [HttpPost]
        public ActionResult<User> Add(User user)
        {
            _userRepository.Add(user);
            return CreatedAtRoute("Getuser", new { id = user.Id}, user);
        }        

        // PUT api/users/{id}
        [HttpPut("{id:length(24)}")]
        public ActionResult<User> Update(string id, User newuser)
        {
            var user = _userRepository.Get(id);
            if (user == null) return NotFound();            
            _userRepository.Update(id, newuser);
            return CreatedAtRoute("Getuser", new { id = id }, newuser);
        }     

        // DELETE api/users/{id}
        [HttpDelete("{id:length(24)}")]        
        public ActionResult<User> Delete(string id)
        {
            var user = _userRepository.Get(id);
            if (user == null) return NotFound();            
            _userRepository.Delete(id);
            return NoContent();
        }

        [HttpOptions]
        public ActionResult Options() {
            Response.Headers.Add("Allow", "DELETE,GET,OPTIONS,POST,PUT");
            return new OkResult();
        }     

        [HttpHead]
        public ActionResult<IEnumerable<User>> Head()
        {
            var users = _userRepository.Get();
            return new JsonResult(users);
        }         

    }
}
