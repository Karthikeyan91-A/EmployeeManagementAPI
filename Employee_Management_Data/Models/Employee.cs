﻿using System;
using System.Collections.Generic;

namespace Employee_Management_Data.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
