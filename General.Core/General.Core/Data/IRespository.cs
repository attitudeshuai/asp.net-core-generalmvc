using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace General.Core.Data
{
    /// <summary>
    /// 仓储模型接口
    /// </summary>
    public interface IRespository<TEntity> where TEntity : class
    {
        /// <summary>
        /// ef数据库上下文
        /// </summary>
        DbContext DbContext { get; }
        /// <summary>
        /// 实体集
        /// </summary>
        DbSet<TEntity> Entities { get; }

        /// <summary>
        /// 获取全部数据
        /// </summary>
        IQueryable<TEntity> Table { get; }
         
        /// <summary>
        /// 获取信息通过Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        TEntity GetById(object Id);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Add(TEntity entity);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Update(TEntity entity);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Remove(TEntity entity);
    }
}
