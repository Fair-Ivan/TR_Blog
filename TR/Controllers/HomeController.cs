namespace TR.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using TR.Dto;
    using TR.ILogicHandler;
    using TR.Unit;

    /// <summary>
    /// 主界面控制器
    /// </summary>
    [Hidden]
    [Route("Home")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserLogicHandler userLogicHandler;

        public HomeController(IUserLogicHandler logicHandler)
        {
            userLogicHandler = logicHandler;
        }

        /// <summary>
        /// 主界面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Home()
        {
            ViewBag.User = this.User.FindFirst(ClaimTypes.Name).Value;
            return View();
        }

        /// <summary>
        /// 修改密码界面
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("Page/Changepwd/{userName}")]
        public IActionResult ChangePwd(string userName)
        {
            ViewBag.user = userName;
            return View();
        }

        [HttpPost("ChangePwd")]
        public ResultData Change(string username, string pwd, string newpwd)
        {
            ResultData result = new ResultData();
            var user = userLogicHandler.GetUsers(username, pwd);
            bool flag = false;
            if (user != null)
            {
                user.Password = newpwd;
                flag = userLogicHandler.UpdateUsers(user);
            }
            if (flag)
            {
                result.Code = 200;
                result.Msg = "修改成功！";
            }else
            {
                result.Code = 500;
                result.Msg = "修改失败！";
            }

            return result;
        }
    }
}
