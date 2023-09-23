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
    public class RequestsListModel : PageModel
    {
        private readonly Hweb.data.hwebDBcontext _context;

        public RequestsListModel(Hweb.data.hwebDBcontext context)
        {
            _context = context;
        }

        public IList<Requests> Requests { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Requests != null)
            {
                Requests = await _context.Requests.ToListAsync();
            }
        }
    }
}
