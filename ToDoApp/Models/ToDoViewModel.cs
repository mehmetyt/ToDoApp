using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    public class ToDoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;
        public bool Done { get; set; }
    }
}
