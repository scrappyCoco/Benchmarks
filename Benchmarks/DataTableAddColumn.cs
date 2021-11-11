using System.Data;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmarks;

[SimpleJob(RuntimeMoniker.Net60)]
public class DataTableAddColumn
{
    private Okvedtem[]? _items;

    [GlobalSetup]
    public void Setup()
    {
        List<Okvedtem> okvedtemList = new ();
        // Source: https://rosstat.gov.ru/opendata/7708234640-okved2
        using StreamReader streamReader = new StreamReader("okved2.csv");
        for (string? str;(str = streamReader.ReadLine()) != null;)
        {
            string[] strArray = str.Split(';');
            okvedtemList.Add(new Okvedtem(strArray[1], strArray[2], strArray[0]));
        }
        _items = okvedtemList.ToArray();
    }

    [Benchmark(Baseline = true)]
    public DataTable AddBulk()
    {
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add("Group", typeof (string));
        dataTable.Columns.Add("Code", typeof (string));
        dataTable.Columns.Add("Description", typeof (string));
        foreach (Okvedtem okvedtem in _items!)
        {
            dataTable.Rows.Add(okvedtem.Group, okvedtem.Code, okvedtem.Description);
        }
        return dataTable;
    }

    [Benchmark]
    public DataTable AddByColumnName()
    {
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add("Group", typeof (string));
        dataTable.Columns.Add("Code", typeof (string));
        dataTable.Columns.Add("Description", typeof (string));
        foreach (Okvedtem okvedtem in _items!)
        {
            DataRow row = dataTable.NewRow();
            row["Group"] = okvedtem.Group;
            row["Code"] = okvedtem.Code;
            row["Description"] = okvedtem.Description;
            dataTable.Rows.Add(row);
        }
        return dataTable;
    }
}