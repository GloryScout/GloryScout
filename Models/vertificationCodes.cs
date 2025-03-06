using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GloryScout.Models
{
	public class vertificationCodes
	{
		[Key]
		public Guid ID { get; set; }

		public bool IsUsed { get; set; } = false;
		public DateTime ExpiresAt { get; set; }= DateTime.Now.AddMinutes(10);

		public string Code { get; set; }

		//foreign key
		public Guid UserID { get; set; }
		[ForeignKey(nameof(UserID))]
		public User User { get; set; }


		//will be added maniually
		public string UserEmail { get; set; }
	}
}
