using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hweb;
using Hweb.data;

namespace Hweb.Pages.Request
{
    public class CreateRequestsModel : PageModel
    {
        private readonly Hweb.data.hwebDBcontext _context;

        public CreateRequestsModel(Hweb.data.hwebDBcontext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Requests Requests { get; set; } = default!;
        public userRequests userRequests { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
        
            if (!ModelState.IsValid || _context.Requests == null || Requests == null)
            {
                return Page();
            }
            userRequests = new userRequests();

            userRequests.username = User.Identity.Name;

            userRequests.Requests = Requests;

           

            _context.userRequests.Add(userRequests);
            await _context.SaveChangesAsync();

            return RedirectToPage("./MyRequests");
        }
    }
}
