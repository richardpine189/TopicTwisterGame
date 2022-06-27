
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class CategoriesGetter : ICategoriesGetter
    {
        ICategoriesRepository _categoryRepository;

        public CategoriesGetter(ICategoriesRepository categoriesDB)
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

