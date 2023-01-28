using Bilet_6.Models.Base;

namespace Bilet_6.Models
{
    public class Pozition:BaseEntity
    {
        public string Name {get;set;}
        public ICollection<Team> Teams { get; set;}
    }
}
