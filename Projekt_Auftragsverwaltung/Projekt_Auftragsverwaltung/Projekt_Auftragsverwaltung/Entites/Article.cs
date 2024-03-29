﻿namespace Projekt_Auftragsverwaltung.Tables;

public class Article
{
    public int ArticleId { get; set; }
    public string ArticleName { get; set; }
    public decimal Price { get; set; }
    public int ArticleGroupId { get; set; }
    public ArticleGroup ArticleGroup { get; set; }
    public virtual List<ArticlePosition> OrderPositions { get; set; }
}