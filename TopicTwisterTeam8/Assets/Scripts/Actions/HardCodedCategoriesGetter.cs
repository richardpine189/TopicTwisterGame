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
        ICategoriesRepository _categoryRepository;

        public HardCodedCategoriesGetter(ICategoriesRepository categoriesDB)
        {
            _categoryRepository = categoriesDB;
        }
        public string[] GetCategories()
        {
            List<Category> categories = _categoryRepository.GetCategories(5); // HARDCODED
            String[] categoriesName = categories.Select(x => x.Name).ToArray();
            return categoriesName;
        }
    }
}
