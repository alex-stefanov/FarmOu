using System.ComponentModel.DataAnnotations;

namespace FarmOu.Data.Models;

public class ZdravkaTable
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;
}