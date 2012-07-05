using System.ComponentModel.DataAnnotations;

namespace NewsManagement.Models
{
    public class CategoryModel
    {
        [Required]
        public string CategoryName { get; set; }
        public int IdFather { get; set; }
        public int OrderCategory { get; set; }
        public string Url { get; set; }
        public int IdRootCategory { get; set; }
    }
}