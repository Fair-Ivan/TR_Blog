using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TR.ILogicHandler;
using TR.Models;
using TR.Unit;

namespace TR.Controllers
{
    /// <summary>
    /// 登陆控制器
    /// </summary>
    [Hidden]
    public class LoginController : Controller
    {
        private readonly IUserLogicHandler userLogicHandler;


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logicHandler"></param>
        public LoginController(IUserLogicHandler logicHandler)
        {
            userLogicHandler = logicHandler;
        }

        /// <summary>
        /// 登录界面
        /// </summary>
        /// <returns></returns>
        [HttpGet("login")]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 注销，退出登录
        /// </summary>
        /// <returns></returns>
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //获取登录Claim中的userId
            var UserName = this.User.FindFirst(ClaimTypes.Name).Value;
            return Ok(200);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpGet("login/{name}/{password}")]
        public async Task<IActionResult> Login(string name, string password)
        {
            var user = userLogicHandler.GetUsers(name, password);
            if (user !=null)
            {                
                user.AuthenticationType = CookieAuthenticationDefaults.AuthenticationScheme;
                var identity = new ClaimsIdentity(user.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                return Ok(200);
            }
            else
            {
                return Ok(500);
            }
        }
    }
}