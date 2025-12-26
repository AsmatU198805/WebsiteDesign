using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Controllers;
using WebAPI.Data;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public UsersController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext; 
        }


        [HttpPost]
        public async Task<ActionResult<bool>> SaveUsers(User user)
        {
            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();
            return Ok(true);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var Users= await _appDbContext.Users.ToListAsync();
            if(Users==null || Users.Count<=0)
                return Ok(Users);
            return Users;
        }



        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(LoginRequestDTO request)
        {
            var user = await _appDbContext.Users
                .FirstOrDefaultAsync(x =>
                    x.UserName == request.UserName &&
                    x.Password == request.Password);

            if (user == null)
                return Unauthorized("Invalid username or password");

            return Ok(user);
        }
    }
}
