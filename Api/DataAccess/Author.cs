using System;
using System.Collections.Generic;

namespace Api.DataAccess;

public partial class Author
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateOnly? Birthdate { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
