namespace TR.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TR.Dto;
    using TR.ILogicHandler;
    using TR.Unit;

    /// <summary>
    /// 博客控制器
    /// </summary>
    [Hidden]
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IBlogLogicHandler blogLogicHandler;
        private readonly IHostingEnvironment hostingEnvironment;

        public BlogController(IBlogLogicHandler blogLogic, IHostingEnvironment hosting)
        {
            blogLogicHandler = blogLogic;
            hostingEnvironment = hosting;
        }

        /// <summary>
        /// 博客首页
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (this.User.Claims.Count() == 0)
            {
                ViewBag.User = null;
            }
            else
            {
                ViewBag.User = this.User.FindFirst(ClaimTypes.Name).Value;
            }
            return View();
        }

        /// <summary>
        /// 文章列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("Page/blogs")]
        public IActionResult BlogPage()
        {
            return View();
        }

        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("blogs")]
        public ResultData GetBlogs(int pageIndex, int limit, string author, string title)
        {
            int count = 0;
            ResultData resultData = new ResultData();
            resultData.Data = blogLogicHandler.GetBlogs(pageIndex, limit, author, title, out count);
            resultData.Count = count;

            return resultData;
        }

        /// <summary>
        /// 文章查看界面
        /// </summary>
        /// <returns></returns>
        [HttpGet("Page/artcle/{id}")]
        [AllowAnonymous]
        public IActionResult artclePage(int id)
        {
            ViewBag.id = id;
            return View();
        }

        /// <summary>
        /// 新增文章页面
        /// </summary>
        /// <returns></returns>
        [HttpGet("Page/blogs/add")]
        public IActionResult AddBlog()
        {
            return View();
        }

        /// <summary>
        /// 保存文章
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="airtle">文章数据</param>
        /// <returns>ResultData</returns>
        [HttpPost("blogs/save")]
        public ResultData SaveBlog(string title, string airtle)
        {
            ResultData resultData = new ResultData();
            string autor = this.User.FindFirst(ClaimTypes.Name).Value;
            if (blogLogicHandler.SaveBlogs(autor, title, airtle))
            {
                resultData.Code = 200;
                resultData.Msg = "操作成功！";
            }
            else
            {
                resultData.Code = 500;
                resultData.Msg = "操作失败！";
            }

            return resultData;
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("images/save")]
        public IActionResult SaveImages(IFormFile file)
        {
            long dateTime = DateTime.Now.ToFileTimeUtc();
            string[] template = file.FileName.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            string fileName = Path.Combine(hostingEnvironment.WebRootPath, "Upload", dateTime + "_" + template[template.Length - 1]);
            if (System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
            }

            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                    object data = Json(new { code = 0, msg = "上传成功", data = new { src = Path.Combine("/Upload/", dateTime + "_" + template[template.Length - 1]) } }).Value;

                    return Json(data);
                }
            }
            catch (Exception)
            {
                object data = Json(new { code = 404, msg = "上传失败", data = new { src = fileName } }).Value;
                return Json(data);
            }
        }

        /// <summary>
        /// 读者界面
        /// </summary>
        /// <returns></returns>
        [HttpGet("Page/author")]
        public IActionResult AuthorPage()
        {
            return View();
        }

        /// <summary>
        /// 获取主页博客列表
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("indexBlogs")]
        public ResultData GetIndexBlogs()
        {
            ResultData result = new ResultData();
            result.Code = 200;
            result.Data = blogLogicHandler.GetIndexBlogs();

            return result;
        }

        /// <summary>
        /// 获取文章内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetBlog/{id}")]
        [AllowAnonymous]
        public ResultData GetBlogData(int id)
        {
            ResultData resultData = new ResultData();
            resultData.Code = 200;
            resultData.Data = blogLogicHandler.GetBlogData(id);

            return resultData;
        }

        /// <summary>
        /// 种类界面
        /// </summary>
        /// <returns></returns>
        [HttpGet("Page/type")]
        public IActionResult TypePage()
        {
            return View();
        }

        /// <summary>
        /// 获取读者数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="limit"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpGet("author")]
        public ResultData GetAuthor(int pageIndex, int limit, string author)
        {
            int count = 0;
            ResultData resultData = new ResultData();
            resultData.Data = blogLogicHandler.GetAuthors(pageIndex, limit, author, out count);
            resultData.Count = count;

            return resultData; 
        }
    }
}