namespace TR.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 作者表
    /// </summary>
    public class Author
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 加入时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Intridution { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
