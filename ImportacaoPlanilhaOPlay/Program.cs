using System.Data;
using ImportacaoPlanilhaOPlay.Classes;
using ImportacaoPlanilhaOPlay.Context;
using ImportacaoPlanilhaOPlay.Context.Entities;

Console.WriteLine("Informe o caminho do arquivo CSV:");
var filePath = Console.ReadLine();


if (!File.Exists(filePath))
{
    Console.WriteLine("Arquivo não encontrado.");
    return;
}

var dataTable = CsvReader.ReadCsvToDataTable(filePath);

if (dataTable.Rows.Count == 0)
{
    Console.WriteLine("O arquivo CSV está vazio.");
    return;
}


Console.WriteLine("Informe o tamanho do lote (número inteiro):");
var valueInsert = Console.ReadLine();

var batchSize = string.IsNullOrWhiteSpace(valueInsert) ? 500 : int.Parse(valueInsert);


await using var context = new AppDbContext();

var productVariations = new List<ProductVariation>();

foreach (DataRow row in dataTable.Rows)
{
    string? name = null;
    string? measurementUnit = null;
    string? observations = null;
    int? id = null;
    int? itemId = null;
    int? brandId = null;

    if (dataTable.Columns.Contains("name"))
    {
        name = row["name"] as string;
    }

    if (dataTable.Columns.Contains("measurement_unit"))
    {
        measurementUnit = row["measurement_unit"] as string;
    }

    if (dataTable.Columns.Contains("observations"))
    {
        observations = row["observations"] as string;
    }

    if (dataTable.Columns.Contains("id") && row["id"] != DBNull.Value)
    {
        if (int.TryParse((string?)row["id"], out var valueNumber))
            id = valueNumber;
    }

    if (dataTable.Columns.Contains("item_id") && row["item_id"] != DBNull.Value)
    {
        if (int.TryParse((string?)row["item_id"], out var valueNumber))
            itemId = valueNumber;
    }

    if (dataTable.Columns.Contains("brand_id") && row["brand_id"] != DBNull.Value)
    {
        if (int.TryParse((string?)row["brand_id"], out var valueNumber))
            brandId = valueNumber;
    }

    var productVariation = new ProductVariation(name, measurementUnit,
        observations, id,
        itemId, brandId);

    productVariations.Add(productVariation);
    if (productVariations.Count % batchSize == 0 || row == dataTable.Rows[^1])
    {
        await context.ProductVariations.AddRangeAsync(productVariations);
        await context.SaveChangesAsync();
        productVariations.Clear();
    }
}

if (productVariations.Count > 0)
{
    await context.ProductVariations.AddRangeAsync(productVariations); 
    await context.SaveChangesAsync();  
}

Console.WriteLine("Importação concluída com sucesso!");