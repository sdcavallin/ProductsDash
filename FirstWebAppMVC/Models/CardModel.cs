using System.ComponentModel;

namespace FirstWebAppMVC.Models
{
    public class CardModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Effect { get; set; }

        [DisplayName("Released On")]
        public DateTime ReleaseDate { get; set; }

    }
}
