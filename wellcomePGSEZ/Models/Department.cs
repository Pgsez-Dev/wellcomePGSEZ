﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace wellcomePGSEZ.Models;

public partial class Department
{
    public int DId { get; set; }

    public string DName { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}