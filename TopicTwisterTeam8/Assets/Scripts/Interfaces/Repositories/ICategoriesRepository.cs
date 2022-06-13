using System.Collections.Generic;
using TopicTwister.Assets.Scripts.Models;

namespace Assets.Scripts.Interfaces
{
    public interface ICategoriesRepository
    {
        public List<Category> GetCategories();
        public List<Category> GetCategories(int amount);
    }
}