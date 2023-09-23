using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hweb;
using Hweb.data;
using System.Security.Claims;

namespace Hweb.Pages.Request
{
    public class EditModel : PageModel
    {
        private readonly Hweb.data.hwebDBcontext _context;

        public EditModel(Hweb.data.hwebDBcontext context)
        {
            _context = context;
        }

        [BindProperty]
        public Requests Requests { get; set; } = default!;
        [BindProperty] public string RequestLogDescription { get; set; } = String.Empty;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Requests == null)
            {
                return NotFound();
            }

            var requests =  await _context.Requests.FirstOrDefaultAsync(m => m.requestID == id);
            if (requests == null)
            {
                return NotFound();
            }
            Requests = requests;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            completed_request_log completed_Request_Log = new completed_request_log();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Requests).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestsExists(Requests.requestID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            if (!String.IsNullOrEmpty(RequestLogDescription))
            {
                completed_Request_Log.requestID = Requests.requestID;
                completed_Request_Log.request_update_description = RequestLogDescription;
                completed_Request_Log.time_completed = DateTime.Now;
                _context.completed_request_log.Add(completed_Request_Log);
                await _context.SaveChangesAsync();
            
            }
                
            if (User.IsInRole("Admin"))
            {
                return RedirectToPage("./RequestsList");
            }
            else
            {
                return RedirectToPage("./MyRequests");
            }
          
        }

        private bool RequestsExists(int id)
        {
          return (_context.Requests?.Any(e => e.requestID == id)).GetValueOrDefault();
        }
    }
}
