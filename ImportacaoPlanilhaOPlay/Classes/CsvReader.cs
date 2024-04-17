using System.Data;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace ImportacaoPlanilhaOPlay.Classes;

public static class CsvReader
{
    public static DataTable ReadCsvToDataTable(string filePath)
    {
        var dataTable = new DataTable();

        using var parser = new TextFieldParser(filePath, Encoding.UTF8);
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");

        // Assume que a primeira linha contém os cabeçalhos
        var headers = parser.ReadFields();
        foreach (var header in headers!)
            dataTable.Columns.Add(header);

        while (!parser.EndOfData)
        {
            var rows = parser.ReadFields();
            dataTable.Rows.Add(rows);
        }

        return dataTable;
    }
}