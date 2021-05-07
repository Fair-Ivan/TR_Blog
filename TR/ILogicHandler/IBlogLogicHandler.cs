namespace TR.ILogicHandler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TR.Dto;
    using TR.Models;

    public interface IBlogLogicHandler
    {
        List<BlogDto> GetBlogs(int pageIndex, int limit, string author, string title, out int count);

        List<Author> GetAuthors(int pageIndex, int limit, string author, out int count);

        /// <summary>
        /// 保存文章
        /// </summary>
        /// <returns>bool</returns>
        bool SaveBlogs(string author, string title, string data);

        BlogDto GetBlogData(int id);

        List<BlogDto> GetIndexBlogs();
    }
}
