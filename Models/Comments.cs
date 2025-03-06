using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GloryScout.Models
{
	public class Comments
	{
		[Key]
		public Guid Id { get; set; }


		//foreign key
		public Guid PostId { get; set; }
		[ForeignKey(nameof(PostId))]
		public Posts Posts { get; set; }


		//foreign key
		public Guid UserID { get; set; }
		[ForeignKey(nameof(UserID))]
		public User User { get; set; }


		public string? CommentedText { get; set; }
		public DateTime CreatedAt { get; set; }=DateTime.Now;
	}
}
