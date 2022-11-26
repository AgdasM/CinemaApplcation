using EnocaChallenge.Domain.Common;
using System;
using System.Collections.Generic;

namespace EnocaChallenge.Domain.Entities;

public partial class GösterimTbl : BaseEntity
{
    public int Id { get; set; }

    public int? SalonId { get; set; }

    public int? FilmId { get; set; }

    public string? GösterimTarihi { get; set; }

    public virtual FilmTbl? Film { get; set; }

    public virtual SalonTbl? Salon { get; set; }
}
