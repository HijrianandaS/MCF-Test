using System.ComponentModel.DataAnnotations;

namespace BackendMCF.Models
{
    public class MsUser
    {
        [Key]
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
