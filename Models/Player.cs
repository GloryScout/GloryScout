using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GloryScout.Models
{
    public class Player
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
		[Required]
		public string position { get; set; }
        public string? DomainantFoot { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Bio { get; set; }
        public int weight { get; set; }
        public int height { get; set; }
        public string? CurrentTeam { get; set; }
        public Guid UserId { get; set; }
		[ForeignKey(nameof(UserId))]
		public User User { get; set; }

        ICollection<Application>? Applications { get; set; }


    }
}
