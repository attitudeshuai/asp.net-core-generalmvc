using General.Bussiness.ISerivces;
using General.Domian.Entity;
using General.Domian.Param;
using General.Framework.Controllers.Admin;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace General.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class PersonController : PublicAdminController
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            this._personService = personService;
        }
        /// <summary>
        /// 视图首页
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {

            var list = await _personService.GetAllAsync();
            return View(list);
        }
        /// <summary>
        /// 新增视图
        /// </summary>
        /// <returns></returns> 
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// 修改视图
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Update(int Id)
        {
            var person = await _personService.GetByIdAsync(Id);

            return View(person);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(Param_Person param)
        {
            Person person = new Person()
            {
                Name = param.Name,
                Age = param.Age
            };
            var flag = await _personService.AddPersonAsync(person);

            if (flag)
            {
                Result.status = true;
                Result.message = "新增成功";
                return Json(Result);
            }
            else
            {
                return Json(Result);
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Update(Param_Person param)
        {
            Person person = new Person()
            {
                Id = param.Id,
                Name = param.Name,
                Age = param.Age
            };
            var flag = await _personService.ModifyPersonAsync(person);

            if (flag)
            {
                Result.status = true;
                Result.message = "修改成功";
                return Json(Result);
            }
            else
            {
                return Json(Result);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns> 
        public async Task<IActionResult> Delete(int Id)
        { 
            var flag = await _personService.DeleteAsync(Id);

            if (flag)
            {
                Result.status = true;
                Result.message = "删除成功";
                return Json(Result);
            }
            else
            {
                return Json(Result);
            }
        }
    }
}
