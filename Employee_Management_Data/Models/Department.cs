using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Employee_Management_Data.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
