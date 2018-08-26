using General.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace General.Domian
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly _DbContext _db;

        public EfUnitOfWork(_DbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// ef上下文
        /// </summary>
        public DbContext dbContext
        {
            get
            {
                return _db;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveChangeAysnc()
        {
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
