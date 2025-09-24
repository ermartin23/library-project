using System;
using System.Collections.Generic;

namespace Api.DataAccess;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? Publishedyear { get; set; }

    public int? Genreid { get; set; }

    public int? Authorid { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual Author? Author { get; set; }

    public virtual Genre? Genre { get; set; }
}
