namespace TR.Models
{
    using System;

    /// <summary>
    /// 博客表
    /// </summary>
    public class Blog
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 种类
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 种类id
        /// </summary>
        public string CategoryID { get; set; }

        /// <summary>
        /// 标记
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// 资源url
        /// </summary>
        public string SourceUrl { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { set; get; }
        
        /// <summary>
        /// 编辑时间
        /// </summary>
        public DateTime EditTime { set; get; }

        /// <summary>
        /// 文章浏览数
        /// </summary>
        public string Pv { set; get; }

        /// <summary>
        /// 作者id
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual Author Author { get; set; }
    }
}
