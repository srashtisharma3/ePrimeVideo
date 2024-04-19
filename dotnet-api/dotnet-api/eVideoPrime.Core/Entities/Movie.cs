﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace eVideoPrime.Core.Entities
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string Banner { get; set; }
        public string Duration { get; set; }
        public string Language { get; set; }
        public string VideoUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }

        public virtual Category Category { get; set; }
    }
}