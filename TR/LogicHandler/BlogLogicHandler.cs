namespace TR.LogicHandler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TR.Dto;
    using TR.ILogicHandler;
    using TR.IRepositories;
    using TR.Models;

    public class BlogLogicHandler : IBlogLogicHandler
    {
        private readonly IBlogRepository blogRepository;

        public BlogLogicHandler(IBlogRepository blogReposit)
        {
            blogRepository = blogReposit;
        }

        /// <summary>
        /// 获取读者列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="limit"></param>
        /// <param name="author"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Author> GetAuthors(int pageIndex, int limit, string author, out int count)
        {
            return blogRepository.GetAuthors(pageIndex, limit, author, out count);
        }

        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="limit"></param>
        /// <param name="author"></param>
        /// <param name="title"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<BlogDto> GetBlogs(int pageIndex, int limit, string author, string title, out int count)
        {
            return blogRepository.GetBlogs(pageIndex, limit, author, title, out count);
        }

        /// <summary>
        /// 保存文章
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="data">文章</param>
        /// <returns>bool</returns>
        public bool SaveBlogs(string author, string title, string data)
        {
            Blog blog = new Blog
            {
                Title = title,
                Pv = "0",
                Content = data,
                CreateTime = DateTime.Now,
                EditTime = DateTime.Now     
            };

            return blogRepository.SaveBlogs(author, blog);
        }

        /// <summary>
        /// 获取文章内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BlogDto GetBlogData(int id)
        {
            return blogRepository.GetBlogData(id);
        }

        /// <summary>
        /// 获取首页博客
        /// </summary>
        /// <returns></returns>
        public List<BlogDto> GetIndexBlogs()
        {
            return blogRepository.GetIndexBlogs();
        }
    }
}
