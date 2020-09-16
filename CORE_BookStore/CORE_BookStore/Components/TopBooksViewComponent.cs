using CORE_BookStore.Data;
using CORE_BookStore.Models;
using CORE_BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_BookStore.Components
{
    public class TopBooksViewComponent:ViewComponent 
    {
        //dependencies injection resolve
        private readonly BookRepository _context = null;

        public TopBooksViewComponent(BookRepository context )
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var model = await _context.GetTopBooksAsync(count);
            return View(model);
        }
    }
}
