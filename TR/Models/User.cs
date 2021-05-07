namespace TR.Models
{
    using System;

    /// <summary>
    /// 用户表
    /// </summary>
    public class User
    {
        /// <summary>
        /// userid
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 用户账户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 新增时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime EditTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDelete { get; set; }

        /// <summary>
        /// 授权
        /// </summary>
        public string AuthenticationType { get; internal set; }
    }
}
