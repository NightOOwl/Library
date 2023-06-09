﻿using System;

namespace Lib.Domain
{
    public class Book
    {
        public Guid AuthorId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateOnly PublicationDate { get; set; }
        public DateTime? EditTime { get; set; }
    }
}
