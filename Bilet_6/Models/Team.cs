using Bilet_6.Models.Base;

namespace Bilet_6.Models
{
    public class Team:BaseEntity
    {
        public int PozitionId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public Pozition Pozition { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string GooglePlus { get; set;}
    }
}
