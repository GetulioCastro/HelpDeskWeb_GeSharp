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
    public class AssignModel : PageModel
    {
        private readonly Hweb.data.hwebDBcontext _context;

        public AssignModel(Hweb.data.hwebDBcontext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            userRequests userRequests = new userRequests();
            userRequests.username = User.Identity.Name;
            userRequests.requestID = id;

            _context.userRequests.Add(userRequests);
            await _context.SaveChangesAsync();

            return Page();
        }

        
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    }
}
