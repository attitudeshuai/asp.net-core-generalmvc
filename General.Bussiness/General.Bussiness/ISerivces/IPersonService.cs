using General.Domian.Dto;
using General.Domian.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Bussiness.ISerivces
{
    public interface IPersonService
    {
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        Task<List<Person>> GetAllAsync();
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<Dto_Person> GetByIdAsync(int Id);

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        Task<bool> AddPersonAsync(Person person);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<bool> ModifyPersonAsync(Person person);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int Id);
    }
}
