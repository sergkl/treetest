using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class TestRepository : IRepository
    {
        private List<Category> categories;

        public void Initialization<T>(List<T> categories) where T : class
        {
            this.categories = new List<Category>();

            foreach (var categoryObj in categories)
            {
                Type t = categoryObj.GetType();
                var categoryId = t.GetProperty("CategoryId");
                var parentCategoryId = t.GetProperty("ParentCategoryId");
                var name = t.GetProperty("Name");
                var keywords = t.GetProperty("Keywords");

                var category = new Category();

                category.CategoryId = (int)categoryId.GetValue(categoryObj);
                category.ParentCategoryId = (int)parentCategoryId.GetValue(categoryObj);
                category.Name = (string)name.GetValue(categoryObj);
                category.Keywords = (string)keywords.GetValue(categoryObj);

                this.categories.Add(category);
            }
        }

        public List<Category> GetAllCagegories()
        {
            return categories;
        }

        public Category GetCategory(long id, bool replaceNullableKeywordWithParent = true)
        {
            Category category = categories.Where(a => a.CategoryId == id).FirstOrDefault();

            if (category == null)
            {
                return null;
            }

            if (replaceNullableKeywordWithParent)
            {
                if (string.IsNullOrEmpty(category.Keywords))
                {
                    Category parentCategory = GetCategory(category.ParentCategoryId, true);
                    if (parentCategory != null)
                    {
                        category.Keywords = parentCategory.Keywords;
                    }
                }
            }

            return category;
        }

        public List<int> GetCategoryIdsByLevel(int level)
        {
            List<int> categoryIds = new List<int>();

            foreach (Category category in categories)
            {
                int currentCategoryLevel = 0;
                CalculateLevelDepth(category, ref currentCategoryLevel);
                if (currentCategoryLevel == level)
                {
                    categoryIds.Add(category.CategoryId);
                }
            }

            return categoryIds;
        }

        private void CalculateLevelDepth(Category category, ref int level)
        {
            if (category == null)
            {
                return;
            }

            if (category.ParentCategoryId == -1)
            {
                level++;
            }
            else
            {
                Category parentCategory = GetCategory(category.ParentCategoryId);
                level++;
                CalculateLevelDepth(parentCategory, ref level);
            }
        }
    }
}
