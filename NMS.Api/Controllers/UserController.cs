using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NMS.Application;
using NMS.Domain;

namespace NMS.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        ApiResponse response = new ApiResponse();

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("signup")]
        public IActionResult Signup(User user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.UserName))
                {
                    return BadRequest("Invalid data");
                }
                var isSign = _userService.Signup(user);


                return Ok(isSign);
            }
            catch (Exception)
            {

                return BadRequest("An Error Occured from signup");
            }
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(User loginRequest)
        {
            try
            {
                if (string.IsNullOrEmpty(loginRequest.UserName) || string.IsNullOrEmpty(loginRequest.Password))
                {
                    return BadRequest("Invalid data");
                }
                var loginResponse = _userService.Login(loginRequest);

                if (loginResponse == null)
                {
                    return BadRequest($"Invalid credentials");
                }
                if (loginResponse != null)
                {
                    response.Data = loginResponse;
                    return Ok(response);
                }
                else
                {
                    response.Data = null;
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

                response.Data = null;
                return Ok(response);
            }

        }
    }
}
