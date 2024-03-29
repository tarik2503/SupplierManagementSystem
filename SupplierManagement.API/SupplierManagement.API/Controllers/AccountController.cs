using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplierManagement.API.IRepository;
using SupplierManagement.Data.Models;

namespace SupplierManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _account;
        public AccountController(IAccount account)
        {
            _account = account;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Register(UserSignup model)
        {
            bool checkUser = await _account.CheckUser(model.Email);
            if (checkUser)
            {
                var CreateUser = await _account.SignupUser(model);
                if (CreateUser)
                {
                    return Ok(new
                    {

                        Message = "User Registered!"
                    });
                }
                return BadRequest();
            }
            else
            {
                return NotFound(new
                {
                    Message = "User Already Exist"
                });
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login(UserLogin model)
        {
            bool checkUser = await _account.LoginUser(model);
            if (checkUser)
            {
                string token = await _account.CreateToken(model.UserName);
                return Ok(new
                {
                    Token = token,
                    Message = "login success"
                });
            }
            return NotFound(new
            {
                Message = "Entered Email or Password is incorrect!"
            });
        }
    }
}
