﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace wellcomePGSEZ.Models;

public partial class Phone
{
    public short Id { get; set; }

    public string PhoneNumber { get; set; }

    public string PCode { get; set; }

    public string PName { get; set; }

    public byte? PDep { get; set; }

    public string PSerial { get; set; }

    public int? PropertyNumber { get; set; }

    public virtual Department PDepNavigation { get; set; }
}