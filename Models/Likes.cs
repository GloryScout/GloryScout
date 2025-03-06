using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GloryScout.Models
{
	public class Likes
	{
		[Key]
		public Guid Id { get; set; }	

		//foreign key 
		public Guid PostId { get; set; }
		[ForeignKey(nameof(PostId))]
		public Posts Posts { get; set; }
		

		//foreign key 
		public Guid UserId { get; set; }
		[ForeignKey(nameof(UserId))]
		public User User { get; set; }


		public DateTime LikedAt { get; set; }

	}
}
