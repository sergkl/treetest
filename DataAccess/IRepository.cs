using Models;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IRepository
    {
        /// <summary>
        /// Saves any instances of all generic classes to Categories list which repository uses
        /// NOTE: Automapper could be used but I didn't know can we use third party tools for the test task or not
        /// </summary>
        /// <param name="categories">List of objects which we transform to Categories list</param>
        void Initialization<T>(List<T> categories) where T : class;

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        List<Category> GetAllCagegories();

        /// <summary>
        /// Get category by id and replace nullable keyword with parent class if it is needed
        /// </summary>
        /// <param name="id">Category identifier</param>
        /// <returns></returns>
        Category GetCategory(long id, bool replaceNullableKeywordWithParent = true);

        /// <summary>
        ///  Calculates the names of the categories which are of N’th level in the hierarchy
        /// </summary>
        /// <param name="level">Level number</param>
        /// <returns>Returns identifiers of the categories which are of N’th level in the hierarchy</returns>
        List<int> GetCategoryIdsByLevel(int level);
    }
}
