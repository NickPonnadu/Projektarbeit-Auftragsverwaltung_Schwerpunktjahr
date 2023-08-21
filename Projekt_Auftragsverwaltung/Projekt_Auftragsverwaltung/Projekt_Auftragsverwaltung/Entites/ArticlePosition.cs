﻿namespace Projekt_Auftragsverwaltung.Tables;

public class ArticlePosition
{
    public int ArticlePositionId { get; set; }


    public int OrderPositionId { get; set; }
    public OrderPosition OrderPosition { get; set; }

    public int ArticleId { get; set; }
    public Article Article { get; set; }
}