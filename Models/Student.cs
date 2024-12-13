using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models;

public partial class Student
{
    public int SId { get; set; }

    public string SName { get; set; } = null!;

    public DateOnly Dob { get; set; }
    [DataType(DataType.Password)]
    public string SPassword { get; set; } = null!;
    
    public long PhoneNumber { get; set; }

    public string? Email { get; set; }
}
