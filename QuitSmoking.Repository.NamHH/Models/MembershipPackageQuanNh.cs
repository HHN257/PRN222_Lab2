﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace QuitSmoking.Repository.NamHH.Models;

public partial class MembershipPackageQuanNh
{
    public int MembershipPackageQuanNhid { get; set; }

    public string PackageName { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public int DurationDays { get; set; }

    public int? MaxConsultations { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string ModifiedBy { get; set; }

    public virtual ICollection<UserSubscriptionQuanNh> UserSubscriptionQuanNhs { get; set; } = new List<UserSubscriptionQuanNh>();
}