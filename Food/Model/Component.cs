using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Model
{
    public class Component
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public List<string> Emotes = new List<string> { "emote_a.png", "emote_b.png", "emote_c.png", "emote_d.png", "emote_e.png", "emote_none.png" };

        public string GetEmoteByRate 
        {
            get
            {
                return Emotes[Rate];
            }
        }
        public int _Color { get; set; }
        public string GetPicture
        {
            get
            {
                if(_Color == 1)
                {
                    return "red.png";
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
