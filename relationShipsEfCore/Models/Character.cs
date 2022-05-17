using System.Text.Json.Serialization;

namespace RelationShipsEfCore.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public Weapon Weapon { get; set; }
    }
}
