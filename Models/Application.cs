using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GloryScout.Models
{
    public class Application
    {
        [Key]
        public Guid Id { get; set; }
		public string? Status { get; set; }
		public string? Content { get; set; }
		public DateTime SubmittedAt { get; set; } = DateTime.Now;

		public Guid ScoutId { get; set; }
		[ForeignKey(nameof(ScoutId))]
		public Scout Scout { get; set; }

		public Guid PlayerId { get; set; }
		[ForeignKey(nameof(PlayerId))]
		public Player Player { get; set; }
	}
}
