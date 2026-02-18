using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoWebApp.Models;

public class ToDoModel
{
    [Key]
    public int id { get; set; }

    [Display(Name="ToDo Name")]
    public string? name { get; set; }
    [Display(Name ="Available?")]
    public bool instock { get; set; }
}
