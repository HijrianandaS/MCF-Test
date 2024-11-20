using System.ComponentModel.DataAnnotations;

namespace BackendMCF.Models
{
    public class MsStorageLocation
    {
        [Key]
        public string LocationId { get; set; }
        public string LocationName { get; set; }
    }
}
