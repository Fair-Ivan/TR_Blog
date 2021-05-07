namespace TR.IRepositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IBaseRepository<T>
        where T : class
    {
        /// <summary>
        /// 新增一条记录
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>bool</returns>
        bool Save(T entity);

        bool IsExist(Expression<Func<T, bool>> expression);

        /// <summary>
        /// 新增多条记录
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>bool</returns>
        bool SaveList(List<T> entity);

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>int</returns>
        bool Update(T entity);

        /// <summary>
        /// 更新多条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>int</returns>
        bool UpdateList(List<T> entity);

        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <param name="expression">拉姆达表达式</param>
        /// <returns>T</returns>
        T Get(Expression<Func<T, bool>> expression);

        /// <summary>
        /// 获取list
        /// </summary>
        /// <param name="expression">拉姆达表达式</param>
        /// <returns>List<T></returns>
        List<T> List(Expression<Func<T, bool>> expression);

        /// <summary>
        /// 异步获取list
        /// </summary>
        /// <param name="expression">拉姆达表达式</param>
        /// <returns>List<T></returns>
        Task<List<T>> ListAsync(Expression<Func<T, bool>> expression);
    }
}
