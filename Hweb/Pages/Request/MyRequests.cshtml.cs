using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hweb;
using Hweb.data;

namespace Hweb.Pages.Request
{
    public class MyRequestsModel : PageModel
    {
        private readonly Hweb.data.hwebDBcontext _context;

        public MyRequestsModel(Hweb.data.hwebDBcontext context)
        {
            _context = context;
        }

        public IList<userRequests> userRequests { get;set; } = default!;

        public async Task OnGetAsync()
        {
            string username = User.Identity.Name;
            if (_context.userRequests != null)
            {
                
                userRequests = await _context.userRequests.Where(u=>u.username==username).Include(u => u.Requests).ToListAsync();

            }
        }
    }
}
