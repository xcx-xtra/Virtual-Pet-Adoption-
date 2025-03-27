namespace VirtualPetAdoption.Models
{
    //User class with properties for user details
    public class User 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        //Simplified quiz answers (1-5 scale)
        public int PreferredPlayfulness { get; set; }
        public int PreferredAffection { get; set; }

        // Reference to matched pet
        public int? AdoptedPetId { get; set; }
        public Pet AdoptedPet { get; set; }

    }//end class    
}//end namespace