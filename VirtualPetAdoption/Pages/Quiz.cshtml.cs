using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VirtualPetAdoption.Data;
using VirtualPetAdoption.Models;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualPetAdoption.Pages
{
    public class QuizModel : PageModel
    {
        private readonly PetAdoptionContext _context;

        public QuizModel(PetAdoptionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save the user to the database
            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            // Find best match using simplified algorithm
            var allPets = await _context.Pets.ToListAsync();
            int bestMatchId = FindBestMatch(allPets, User);

            // Complete adoption directly
            User.AdoptedPetId = bestMatchId;
            await _context.SaveChangesAsync();

            // Redirect to results page
            return RedirectToPage("./Results", new { userId = User.Id });
        }

        private int FindBestMatch(List<Pet> pets, User user)
        {
            // Simple matching based on playfulness and affection
            Pet bestMatch = null;
            double lowestDifference = double.MaxValue;

            foreach (var pet in pets)
            {
                double difference = 
                    Math.Abs(pet.Playfulness - user.PreferredPlayfulness) +
                    Math.Abs(pet.Affection - user.PreferredAffection);

                if (difference < lowestDifference)
                {
                    lowestDifference = difference;
                    bestMatch = pet;
                }
            }

            return bestMatch?.Id ?? 1; // Default to first pet if no match
        }
    }
}
