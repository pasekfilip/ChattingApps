﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;
using WebAPI.Models.Tables;
namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private UserRepository repository = new UserRepository();

        // GET: api/Users
        [Route("api/Users")]
        [HttpGet]
        public List<User> Get()
        {
            return this.repository.FindAll();
        }
        [Route("api/Users/FindUsersByIDs")]
        [HttpPost]
        public List<User> FindUsersByIDs([FromBody]int[] IDs)
        {
            return this.repository.FindUsersByIDs(IDs);
        }

        [Route("api/Users/FindByUserName")]
        [HttpPost]
        public User FindByUserName([FromBody]string userName)
        {
            return this.repository.FindByUserName(userName);
        }


        // POST: api/User
        [Route("api/Users")]
        [HttpPost]
        public void Post([FromBody]User value)
        {
            this.repository.Create(value);
        }

        // PUT: api/User/5
        [Route("api/Users/{id}")]
        [HttpPost]
        public void Put(int id, [FromBody]User value)
        {
            value.ID = id;
            this.repository.Update(value,id);
        }

        // DELETE: api/User/5
        [Route("api/Users/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            User user = this.repository.FindById(id);
            this.repository.Delete(user);
        }
    }
}
