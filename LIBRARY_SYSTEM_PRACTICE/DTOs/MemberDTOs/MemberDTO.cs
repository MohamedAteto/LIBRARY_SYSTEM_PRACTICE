using System.ComponentModel.DataAnnotations;

namespace LIBRARY_SYSTEM_PRACTICE.DTOs.MemberDTOs
{
    public class MemberDTO
    {
        public string MemberFullName { get; set; }
        public string MemberEmail { get; set; }
        public string MemberPhone { get; set; }
        public int MemberBookcount { get; set; }
    }
}
