using EnocaChallenge.Domain.Common;
using System;
using System.Collections.Generic;

namespace EnocaChallenge.Domain.Entities;

public partial class SalonTbl : BaseEntity
{
    public int SalonId { get; set; }

    public string? SalonAd { get; set; }

    public virtual ICollection<GösterimTbl> GösterimTbls { get; } = new List<GösterimTbl>();
}
