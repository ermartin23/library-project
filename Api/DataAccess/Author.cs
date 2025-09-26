
﻿using System;
using System.Collections.Generic;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
}


