using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GloryScout.Models
{
    public class Scout
    {
        [Key]
        public Guid Id { get; set; }
        public string ClubName { get; set; }
        public string? ProfileDescription { get; set; }
        public string contact_Details { get; set; }
        public string location { get; set; }
        public Guid UserId { get; set; }
		[ForeignKey(nameof(UserId))]
        public User User { get; set; }


		public ICollection<Application>? Applications { get; set; }




       
    }
}
