using EnocaChallenge.Domain.Common;
using System;
using System.Collections.Generic;

namespace EnocaChallenge.Domain.Entities;

public partial class FilmTbl : BaseEntity
{
    public int FilmId { get; set; }

    public string? FilmAd { get; set; }

    public string? FilmYapımyıl { get; set; }

    public virtual ICollection<GösterimTbl> GösterimTbls { get; } = new List<GösterimTbl>();
}
