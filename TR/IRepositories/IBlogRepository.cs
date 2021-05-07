namespace TR.IRepositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TR.Dto;
    using TR.Models;

    /// <summary>
    /// blogres
    /// </summary>
    public interface IBlogRepository : IBaseRepository<Blog>
    {
        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="limit"></param>
        /// <param name="author"></param>
        /// <param name="title"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<BlogDto> GetBlogs(int pageIndex, int limit, string author, string title, out int count);

        List<Author> GetAuthors(int pageIndex, int limit, string author, out int count);

        bool SaveBlogs(string author, Blog blog);

        BlogDto GetBlogData(int id);

        List<BlogDto> GetIndexBlogs();
    }
}
