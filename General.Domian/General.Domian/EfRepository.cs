using General.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Domian
{
    public class EfRepository<TEntity> : IRespository<TEntity> where TEntity : class
    {
        private _DbContext db;
        public EfRepository(_DbContext _db)
        {
            db = _db;
        }

        /// <summary>
        /// ef数据库上下文
        /// </summary>
        public DbContext DbContext
        {
            get
            {
                return db;
            }
        }
        /// <summary>
        /// 实体集
        /// </summary>
        public DbSet<TEntity> Entities
        {
            get
            {
                return db.Set<TEntity>();
            }
        }
        /// <summary>
        /// 获取全部数据
        /// </summary>
        public IQueryable<TEntity> Table
        {
            get
            {
                return Entities;
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Add(TEntity entity)
        {
            Entities.Add(entity); 
        } 
        /// <summary>
        /// 获取信息通过Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public TEntity GetById(object Id)
        {
            return Entities.Find(Id);
        } 
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Remove(TEntity entity)
        {
            Entities.Remove(entity); 
        } 
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified; 
        } 
    }
}
