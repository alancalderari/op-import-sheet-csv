namespace ImportacaoPlanilhaOPlay.Context.Entities;

public class ProductVariation
{
    protected ProductVariation(){} //EFCore

    public ProductVariation(string? name, string? measurementUnit, string? observations,  int? obraPlayId, int? obraPlayItemId, int? obraPlayBrandId)
    {
        Name = name;
        MeasurementUnit = measurementUnit;
        Observations = observations;
        NameComparison = $"{Name}{MeasurementUnit}{Observations}";
        ObraPlayId = obraPlayId;
        ObraPlayItemId = obraPlayItemId;
        ObraPlayBrandId = obraPlayBrandId;
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? MeasurementUnit { get; set; }
    public string? Observations { get; set; }
    public string? NameComparison { get; set; }
    public int? ObraPlayId { get; set; }
    public int? ObraPlayItemId { get; set; }
    public int? ObraPlayBrandId { get; set; }
    public bool Active { get; set; } = true;
    public bool Disregard { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}