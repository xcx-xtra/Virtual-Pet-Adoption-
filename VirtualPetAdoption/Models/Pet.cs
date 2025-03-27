namespace VirtualPetAdoption.Models
{

//Pet class with properties for pet details
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }


        //Simplified traits (1-5 scale)
        public int Playfulness { get; set; }
        public int Affection { get; set; }
    }//end class
}//end namespace