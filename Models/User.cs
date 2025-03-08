using Microsoft.AspNetCore.Identity;
using NuGet.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GloryScout.Models
{
	public class User : IdentityUser<Guid>
	{
		[Key]
		public Guid Id { get; set; }

		[EmailAddress]
		[Required(ErrorMessage = "Email is required !")]
		public string Email { get; set; }

		[PasswordPropertyText]
		[Required(ErrorMessage ="password is required !")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Enter your nationality!")]
		public string Nationality { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public string UserType { get; set; }
		public bool IsVertified { get; set; } = false;


		public ICollection<vertificationCodes>? VertificationCodes { get; set; }
		public ICollection<Posts>? Posts { get; set; }
		public ICollection<Comments>? Comments { get; set; }
		public ICollection<Likes>? Likes { get; set; }

	}
}
