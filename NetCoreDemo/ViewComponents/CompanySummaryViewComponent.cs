using Microsoft.AspNetCore.Mvc;
using NetCoreDemo.Models;
using NetCoreDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDemo.ViewComponents
{
    public class CompanySummaryViewComponent:ViewComponent
    {
        private readonly IDepartmentService _departmentService;

        public CompanySummaryViewComponent(IDepartmentService departmentService)
        {
            this._departmentService = departmentService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string title)
        {
            ViewBag.Title = title;
            var summary = await _departmentService.GetCompanySummary();
            return View(summary);
        }
    }
}
