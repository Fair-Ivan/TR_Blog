using System;

namespace TR.Dto
{
    public class BlogDto
    { /// <summary>
      /// 主键id
      /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 作者名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        public string Top { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 种类
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 标记
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { set; get; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public string AddTime { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        public DateTime EditTime { set; get; }

        /// <summary>
        /// 文章浏览数
        /// </summary>
        public string Pv { set; get; }

        /// <summary>
        /// url
        /// </summary>
        public string Url { set; get; }
    }
}
