using System.Data;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace ImportacaoPlanilhaOPlay.Classes;

public static class CsvReader
{
    public static DataTable ReadCsvToDataTable(string filePath)
    {
        // var dataTable = new DataTable();
        //
        // const char separator = ',';
        //
        // using var reader = new StreamReader(filePath, Encoding.UTF8);
        // var headers = reader.ReadLine()?.Split(separator);
        //
        // foreach (var header in headers!)
        //     dataTable.Columns.Add(header);
        //
        // while(!reader.EndOfStream)
        // {
        //     var rows = reader.ReadLine()!.Split(separator);
        //     var dataRow = dataTable.NewRow();
        //     dataRow.ItemArray = rows;
        //     dataTable.Rows.Add(dataRow);
        // }
        // return dataTable;
        
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