using System.Text.Json.Serialization;

namespace KanbanAPI.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "To Do";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int BoardId { get; set; }

        [JsonIgnore] // prevents ASP.NET from expecting this in POST/PUT requests
        public Board? Board { get; set; }
    }
}
