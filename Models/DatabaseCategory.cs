namespace Models
{
    /// <summary>
    /// Specially added this class for showing that our IRepository can work with any classes which has the same names as in Category class. 
    /// Note class duplications was added specially and could be of course just inherited
    /// You can check how it works in UnitTests project
    /// </summary>
    public class DatabaseCategory
    {
        public int CategoryId { get; set; }

        public int ParentCategoryId { get; set; }

        public string Name { get; set; }

        public string Keywords { get; set; }
    }
}
