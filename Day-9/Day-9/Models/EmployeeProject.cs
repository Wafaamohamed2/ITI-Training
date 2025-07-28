﻿using System;
using System.Collections.Generic;

namespace Day_9.Models;

public partial class EmployeeProject
{
    public int EmployeeId { get; set; }

    public int ProjectId { get; set; }

    public string Role { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
