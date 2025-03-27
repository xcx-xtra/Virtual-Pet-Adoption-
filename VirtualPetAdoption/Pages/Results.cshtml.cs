using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VirtualPetAdoption.Data;
using VirtualPetAdoption.Models;
using System.Threading.Tasks;

namespace VirtualPetAdoption.Pages
{
    public class ResultsModel : PageModel
    {
        private readonly PetAdoptionContext _context;

        public ResultsModel(PetAdoptionContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int UserId { get; set; }

        public Pet? Pet { get; set; }
        public new User? User { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (UserId <= 0)
            {
                return RedirectToPage("./Index");
            }

            User = await _context.Users
                .Include(u => u.AdoptedPet)
                .FirstOrDefaultAsync(u => u.Id == UserId);

            if (User == null || User.AdoptedPetId == null)
            {
                return RedirectToPage("./Index");
            }

            Pet = User.AdoptedPet;

            return Page();
        }
    }
}
