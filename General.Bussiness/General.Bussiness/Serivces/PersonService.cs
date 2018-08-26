using General.Bussiness.ISerivces;
using General.Core.Data;
using General.Domian;
using General.Domian.Dto;
using General.Domian.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Bussiness.Serivces
{
    public class PersonService : IPersonService
    { 
        private readonly IRespository<Person> _personRespository;
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IRespository<Person> personRespository,
            IUnitOfWork unitOfWork)
        {
            this._personRespository = personRespository;
            this._unitOfWork = unitOfWork;
        }
        /// <summary>
        /// 获取所有列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<Person>> GetAllAsync()
        {
            return await _personRespository.Table.ToListAsync();
        }
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Dto_Person> GetByIdAsync(int Id)
        {
            var person= await _personRespository.Entities.FindAsync(Id);
            if (null == person)
                return new Dto_Person();
            Dto_Person dto_Person = new Dto_Person()
            {
                Id = person.Id,
                Name = person.Name,
                Age=person.Age
            };

            return dto_Person;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public async Task<bool> AddPersonAsync(Person person)
        {
            _personRespository.Add(person);

            return await _unitOfWork.SaveChangeAysnc();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> ModifyPersonAsync(Person person)
        {
            _personRespository.Update(person);

            return await _unitOfWork.SaveChangeAysnc();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int Id)
        {
            var person = await _personRespository.Entities.FindAsync(Id);
            if (null == person)
                return await Task.FromResult(false);
            _personRespository.Remove(person);
            return await _unitOfWork.SaveChangeAysnc();
        }
    }
}
