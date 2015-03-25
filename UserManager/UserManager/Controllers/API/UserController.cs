using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserManager.Models;

namespace UserManager.Controllers.API
{
    public class UserController : ApiController
    {
        OctoUsersEntities db = new OctoUsersEntities();
        // GET api/<controller>
        public IEnumerable<User> Get()
        {
            return (from u in db.User
                    select u).ToList();
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(string email)
        {
            try
            {
                User user = (from u in db.User
                             where u.Email.Equals(email)
                             select u).FirstOrDefault();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }

        [HttpPost]
        public int Post(User user)
        {
            try
            {
                using (OctoUsersEntities octoUser = new OctoUsersEntities())
                {
                    octoUser.User.Add(user);
                    octoUser.SaveChanges();
                    return user.Id;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}