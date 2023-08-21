namespace Projekt_Auftragsverwaltung.Tables;

public class ArticleGroup
{
    public int ArticleGroupId { get; set; }
    public string Name { get; set; }
    public int? ParentId { get; set; }
    public int Level { get; set; }
    public List<ArticleGroup> Children { get; set; }

    public List<Article> Articles { get; set; }
}