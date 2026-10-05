using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LIBRARY_SYSTEM_PRACTICE.Models
{
    [Index(nameof(MemberEmail), IsUnique = true)]
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [Required]
        public string MemberFullName { get; set; }
        [Required,EmailAddress]
        public string MemberEmail { get; set; }
        [Required]
        public string MemberPhone { get; set; }

        public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();

    }
}
