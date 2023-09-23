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
    public class DetailsModel : PageModel
    {
        private readonly Hweb.data.hwebDBcontext _context;

        public DetailsModel(Hweb.data.hwebDBcontext context)
        {
            _context = context;
        }

      public Requests Requests { get; set; } = default!;
      public IList<completed_request_log>? completed_Request_Logs { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Requests == null)
            {
                return NotFound();
            }

            var requests = await _context.Requests.FirstOrDefaultAsync(m => m.requestID == id);
            if (requests == null)
            {
                return NotFound();
            }
            else 
            {
                Requests = requests;
            }
            var requestsLog = await _context.completed_request_log.Where(m => m.requestID == id).ToListAsync();


            completed_Request_Logs = requestsLog;
          
            return Page();
        }
    }
}
