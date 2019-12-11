using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HearthServer.Models;
 
namespace HearthServer.Controllers
{
    [Route("[controller]")]
    public class SessionController : Controller
    {
        HearthContext db;
        public SessionController(HearthContext context)
        {
            this.db = context;
        }
 
        [HttpGet]
        // GET session
        public IEnumerable<Session> Get()
        {
            return db.Sessions.Include(rd => rd.Device).Include(m => m.Measurements).ToList();
        }
 
        // GET session/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Session session = db.Sessions.Include(rd => rd.Device).Include(m => m.Measurements).FirstOrDefault(x => x.Id == id);
            if (session == null)
                return NotFound();
            return new ObjectResult(session);
        }
 
        // GET session/GetByDeviceId/?id=2
        [HttpGet("{id}")]
        [Route("[controller]/GetByDeviceId/{id}")]
        [ActionName("GetByDeviceId")]
        public IActionResult GetByDeviceId(int id)
        {
            RegisteredDevice device = db.RegisteredDevices.FirstOrDefault(x => x.Id == id);
            if (device == null)
                return NotFound();
            var sessions = (from session in db.Sessions where session.Device == device select session).ToList();
            return new ObjectResult(sessions);
        }
    
       
        // DELETE session/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Session session = db.Sessions.FirstOrDefault(x => x.Id == id);
            if(session==null)
            {
                return NotFound();
            }
            db.Sessions.Remove(session);
            db.SaveChanges();
            return Ok(session);
        }
    }
}