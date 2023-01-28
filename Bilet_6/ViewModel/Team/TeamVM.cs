using Bilet_6.Models;
using Microsoft.Build.Framework;

namespace Bilet_6.ViewModel
{
    public class TeamVM
    {
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int PozitionId { get; set; }

        [Required]
        public string Surname { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Facebook { get; set; }
        [Required]
        public string Linkedin { get; set; }
        [Required]
        public string GooglePlus { get; set; }
    }
}
