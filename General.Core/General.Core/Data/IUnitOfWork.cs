using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace General.Core.Data
{
    /// <summary>
    /// 工作单元模式接口
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// ef上下文
        /// </summary>
        DbContext dbContext { get; }
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChangeAysnc();
    }
}
