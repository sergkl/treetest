using Models;
using System.Collections.Generic;

namespace DataAccess
{
    public class TestData
    {
        public static List<DatabaseCategory> GetCategories()
        {
            List<DatabaseCategory> categories = new List<DatabaseCategory>();

            categories.Add(new DatabaseCategory { CategoryId = 100, ParentCategoryId = -1, Name = "Business", Keywords = "Money" });
            categories.Add(new DatabaseCategory { CategoryId = 200, ParentCategoryId = -1, Name = "Tutoring", Keywords = "Teaching" });
            categories.Add(new DatabaseCategory { CategoryId = 101, ParentCategoryId = 100, Name = "Accounting", Keywords = "Taxes" });
            categories.Add(new DatabaseCategory { CategoryId = 102, ParentCategoryId = 100, Name = "Taxation" });
            categories.Add(new DatabaseCategory { CategoryId = 201, ParentCategoryId = 200, Name = "Computer" });
            categories.Add(new DatabaseCategory { CategoryId = 103, ParentCategoryId = 101, Name = "Corporate Tax" });
            categories.Add(new DatabaseCategory { CategoryId = 202, ParentCategoryId = 201, Name = "Operating System" });
            categories.Add(new DatabaseCategory { CategoryId = 109, ParentCategoryId = 101, Name = "Small business Tax" });

            return categories;
        }
    }
}
