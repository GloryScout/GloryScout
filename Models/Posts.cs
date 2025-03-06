using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GloryScout.Models
{
	public class Posts
	{
		[Key]
		public Guid Id { get; set; }
		public string? Description { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		//foreign key
		public Guid UserID { get; set; }
		[ForeignKey(nameof(UserID))]
		public User User { get; set; }	
		public string B2_Url_key { get; set; }

		public ICollection<Comments> Comments { get; set; }
		public ICollection<Likes> Likes { get; set; }

	}
}
