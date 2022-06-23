using System.Collections.Generic;


    public interface ICategoriesRepository
    {
        public List<Category> GetCategories();
        public List<Category> GetCategories(int amount);
    }
