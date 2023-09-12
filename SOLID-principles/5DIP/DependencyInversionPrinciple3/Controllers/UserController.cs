using DependencyInversionPrinciple3.Models;
using DependencyInversionPrinciple3.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInversionPrinciple3.Controllers
{
    [ApiController, Route("user")]
    public class UserController : ControllerBase
    {
        // this is not ideal - creating these instances are memory consuming when app scales up
        // dependecy injection (DI) should be use to scale efficiently
        //UserRepo userRepo = new UserRepo();
        //Logbook logbook = new Logbook();

        private IUserRepo _userRepo;
        private ILogbook _logBook;

        // DI implementation
        public UserController(IUserRepo userrepo, ILogbook logbook)
        {
            _userRepo = userrepo;
            _logBook = logbook;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            _logBook.Add("GetAll method used, returning users");
            return _userRepo.GetAll();
        }

        [HttpPost]
        public void Add([FromBody]User user)
        {
            _userRepo.Add(user);
            _logBook.Add($"User {user.Username} was added...");
        }
    }
}
