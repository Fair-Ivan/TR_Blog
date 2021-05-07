namespace TR.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using TR.Dto;
    using TR.IRepositories;
    using TR.Models;

    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {
        public BlogRepository(TrContext trContext)
            : base(trContext)
        {

        }

        public List<Author> GetAuthors(int pageIndex, int limit, string author, out int count)
        {
            var query = db.Author.Where(x => (string.IsNullOrWhiteSpace(author) || x.Name == author));

            count = query.Count();

            return query.Skip(limit * (pageIndex - 1)).Take(limit).ToList();
        }

        /// <summary>
        /// 获取博客内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BlogDto GetBlogData(int id)
        {
            var query = db.Blog.Where(x => id == x.Id).Select(x => new BlogDto
            {
                Title = x.Title,
                Name = x.Author.Name,
                Content = x.Content,
                Id = x.Id,
                Pv = x.Pv,
                Summary = x.Summary,
                CreateTime = x.CreateTime,
                EditTime = x.EditTime,
                Url = x.SourceUrl,
                Top = x.Top.ToString()
            }).FirstOrDefault();

            return query;
        }

        public List<BlogDto> GetBlogs(int pageIndex, int limit, string author, string title, out int count)
        {
            var query = db.Blog.Where(x => (string.IsNullOrWhiteSpace(author) || x.Author.Name == author) && (string.IsNullOrWhiteSpace(title) || x.Title == title)).Select(x => new BlogDto
            {
                Id = x.Id,
                Title = x.Title,
                Top = x.Top == 0 ? "未置顶" : "置顶",
                Name = x.Author.Name,
                Summary = x.Summary,
                Category = x.Category,
                CreateTime = x.CreateTime,
                EditTime = x.EditTime,
                Pv = x.Pv
            });

            count = query.Count();

            return query.Skip(limit * (pageIndex - 1)).Take(limit).ToList();
        }

        /// <summary>
        /// 获取首页博客
        /// </summary>
        /// <returns></returns>
        public List<BlogDto> GetIndexBlogs()
        {
            var query = db.Blog.Select(x => new BlogDto
            {
                Top = x.Top.ToString(),
                AddTime = x.CreateTime.ToString("yyyy-MM-dd"),
                Category = x.Category,
                Summary = x.Summary,
                Id = x.Id,
                Title = x.Title,
                Pv = x.Pv
            });

            return query.OrderByDescending(x => x.AddTime).ToList();
        }

        /// <summary>
        /// 保存接口
        /// </summary>
        /// <param name="author"></param>
        /// <param name="blog"></param>
        /// <returns></returns>
        public bool SaveBlogs(string author, Blog blog)
        {
            int authorId = db.Author.FirstOrDefault(x => x.Name == author).Id;
            blog.AuthorId = authorId;

            db.Blog.Add(blog);
            int flag = db.SaveChanges();

            if(flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
