using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public double Calories { get; set; }
        public double Fat { get; set; }
        public double Carbohydrates { get; set; }
        public double Sugar { get; set; }
        public double Fiber { get; set; }
        public double Protein { get; set; }
        public double Salt { get; set; }
        public string ProductType { get; set; }
        public List<Component> Components { get; set; }

        public string BadComponent
        {
            get 
            {
                if (Components != null)
                {
                    foreach (Component component in Components)
                    {
                        if (component._Color == 1)
                        {
                            return "red.png";
                        }
                    }
                }
                return "";
            }
        }

        public string measured_in
        {
            get
            {
                if(ProductType== "Liquid")
                {
                    return "ml";
                }
                return "g";
            }
        }

        public int Rate { 
            get
            {
                int pkt = 0;
                for (int i = 0; i < 5; i++)
                {
                    if(GetEmoteForCalories == Emotes[i])
                    {
                        pkt += i * 20;
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    if (GetEmoteForFat == Emotes[i])
                    {
                        pkt += i * 10;
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    if (GetEmoteForSugar == Emotes[i])
                    {
                        pkt += i * 20;
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    if (GetEmoteForCarbohydrates == Emotes[i])
                    {
                        pkt += i * 20;
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    if (GetEmoteForSalt == Emotes[i])
                    {
                        pkt += i * 10;
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    if (GetEmoteForProtein == Emotes[i])
                    {
                        pkt += i * 10;
                    }
                }
                pkt += GetRateForComponents * 10;
                return pkt/5;
            } 
        }

        public int GetRateForComponents
        {
            get
            {
                if(Components != null)
                {
                    if (Components.Count == 0)
                    {
                        return 0;
                    }
                    int rate = 0;
                    foreach (var component in Components)
                    {
                        rate += component.Rate;
                    }
                    return rate / Components.Count;
                }
                return 0;
                
            }
        }
        public string GetEmoteByRate { 
            get 
            { 
                if(Rate < 20)
                {
                    return Emotes[0];
                }
                else if (Rate < 40)
                {
                    return Emotes[1];
                }
                else if (Rate < 60)
                {
                    return Emotes[2];
                }
                else if (Rate < 80)
                {
                    return Emotes[3];
                }
                else
                {
                    return Emotes[4];
                }

            } 
        }

        public List<string> Emotes = new List<string> { "emote_a.png", "emote_b.png", "emote_c.png", "emote_d.png", "emote_e.png", "emote_none.png" };

        public string GetEmoteForCalories
        {
            get
            {
                if (ProductType == "Liquid")
                {
                    if (Calories < 12)
                    {
                        return Emotes[4];
                    }
                    else if (Calories < 20)
                    {
                        return Emotes[3];
                    }
                    else if (Calories < 28)
                    {
                        return Emotes[2];
                    }
                    else if (Calories < 36)
                    {
                        return Emotes[1];
                    }
                    else if (Calories >= 36)
                    {
                        return Emotes[0];
                    }
                    else
                    {
                        return Emotes[5];
                    }
                    
                }
                else
                {
                    if (Calories < 200)
                    {
                        return Emotes[4];
                    }
                    else if (Calories < 300)
                    {
                        return Emotes[3];
                    }
                    else if (Calories < 450)
                    {
                        return Emotes[2];
                    }
                    else if (Calories < 550)
                    {
                        return Emotes[1];
                    }
                    else if (Calories >= 550)
                    {
                        return Emotes[0];
                    }
                    else
                    {
                        return Emotes[5];
                    }
                }
            }
        }

        public string GetEmoteForFat
        {
            get
            {
                if (ProductType == "Liquid")
                {
                    if (Fat < 1.0)
                    {
                        return Emotes[4];
                    }
                    else if (Fat < 2.0)
                    {
                        return Emotes[3];
                    }
                    else if (Fat < 7)
                    {
                        return Emotes[2];
                    }
                    else if (Fat < 11)
                    {
                        return Emotes[1];
                    }
                    else if (Fat >= 11)
                    {
                        return Emotes[0];
                    }
                    else
                    {
                        return Emotes[5];
                    }
                }
                else
                {
                    if (Fat < 3)
                    {
                        return Emotes[4];
                    }
                    else if (Fat < 8)
                    {
                        return Emotes[3];
                    }
                    else if (Fat < 16)
                    {
                        return Emotes[2];
                    }
                    else if (Fat < 22)
                    {
                        return Emotes[1];
                    }
                    else if (Fat >= 22)
                    {
                        return Emotes[0];
                    }
                    else
                    {
                        return Emotes[5];
                    }
                    
                }
            }
        }

        public string GetEmoteForCarbohydrates
        {
            get
            {
                if (ProductType == "Liquid")
                {
                    if (Carbohydrates < 1)
                    {
                        return Emotes[4];
                    }
                    else if (Carbohydrates < 4)
                    {
                        return Emotes[3];
                    }
                    else if (Carbohydrates < 6)
                    {
                        return Emotes[2];
                    }
                    else if (Carbohydrates < 8)
                    {
                        return Emotes[1];
                    }
                    else if (Carbohydrates >= 10)
                    {
                        return Emotes[0];
                    }
                    else
                    {
                        return Emotes[5];
                    }
                }
                else
                {
                    if (Carbohydrates < 15)
                    {
                        return Emotes[4];
                    }
                    else if (Carbohydrates < 24)
                    {
                        return Emotes[3];
                    }
                    else if (Carbohydrates < 30)
                    {
                        return Emotes[2];
                    }
                    else if (Carbohydrates < 35)
                    {
                        return Emotes[1];
                    }
                    else if (Carbohydrates >= 35)
                    {
                        return Emotes[0];
                    }
                    else
                    {
                        return Emotes[5];
                    }
                    
                }

            }
        }

        public string GetEmoteForSugar
        {
            get
            {
                if (ProductType == "Liquid")
                {
                    if (Sugar < 2)
                    {
                        return Emotes[4];
                    }
                    else if (Sugar < 4)
                    {
                        return Emotes[3];
                    }
                    else if (Sugar < 6)
                    {
                        return Emotes[2];
                    }
                    else if (Sugar < 8)
                    {
                        return Emotes[1];
                    }
                    else if (Sugar >= 8)
                    {
                        return Emotes[0];
                    }
                    else
                    {
                        return Emotes[5];
                    }
                }
                else
                {
                    if (Sugar < 4)
                    {
                        return Emotes[4];
                    }
                    else if (Sugar < 8)
                    {
                        return Emotes[3];
                    }
                    else if (Sugar < 13)
                    {
                        return Emotes[2];
                    }
                    else if (Sugar < 18)
                    {
                        return Emotes[1];
                    }
                    else if (Sugar >= 18)
                    {
                        return Emotes[0];
                    }
                    else
                    {
                        return Emotes[5];
                    }
                }

            }
        }

        public string GetEmoteForProtein
        {
            get
            {
                if (Protein < 4)
                {
                    return Emotes[0];
                }
                else if (Protein < 6)
                {
                    return Emotes[1];
                }
                else if (Protein < 8)
                {
                    return Emotes[2];
                }
                else if (Protein < 12)
                {
                    return Emotes[3];
                }
                else if (Protein >= 12)
                {
                    return Emotes[4];
                }
                else
                {
                    return Emotes[5];
                }

            }
        }

        public string GetEmoteForSalt
        {
            get
            {
                if (Salt < 0.2)
                {
                    return Emotes[4];
                }
                else if (Salt < 0.5)
                {
                    return Emotes[3];
                }
                else if (Salt < 1.2)
                {
                    return Emotes[2];
                }
                else if (Salt < 1.7)
                {
                    return Emotes[1];
                }
                else if (Salt >= 1.7)
                {
                    return Emotes[0];
                }
                else
                {
                    return Emotes[5];
                }

            }
        }

    }
}
