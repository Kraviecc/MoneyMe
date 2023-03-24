using System.ComponentModel.DataAnnotations;
using MoneyMe.Modules.Investments.Core.Entities;
using MoneyMe.Modules.Investments.Core.Models;

namespace MoneyMe.Modules.Investments.Core.DTO;

internal class InvestmentComponentDto
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }

    [Required]
    [StringLength(1000, MinimumLength = 3)]
    public string Description { get; set; }

    public InvestmentComponentType Type { get; set; }

    public Investment Investment { get; set; }
}