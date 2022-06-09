using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTwister.Assets.Scripts.Models;

namespace Assets.Scripts.Actions
{
    public class HardCodedCategoriesGetter : ICategoriesGetter
    {
        public string[] GetCategories()
        {
            return new string[5] { "Cosas", "Animales", "Color", "Paises", "Marcas" };
        }
    }
}
