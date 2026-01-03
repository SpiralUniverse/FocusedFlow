using System.Text.Json;
using FocusedFlow.Core.Monthly;
using FocusedFlow.Persistence.Abstractions;
using FocusedFlow.Persistence.Mappers;
using FocusedFlow.Persistence.Models;

namespace FocusedFlow.Persistence.Json;

public sealed class JsonMonthlyRecordRepository(string filepath) : IMonthlyRecordRepository
{
    private readonly string _filePath = filepath;

    public IReadOnlyList<MonthlyRecord> LoadAll()
    {
        if (!File.Exists(_filePath))
            return [];

        var json = File.ReadAllText(_filePath);
        var dtos = JsonSerializer.Deserialize<List<MonthlyRecordDto>>(json) ?? [];

        return dtos.Select(MonthlyRecordMapper.FromDto).ToList();
    }

    public MonthlyRecord? Load(int year, int month) =>
        LoadAll().FirstOrDefault(m => m.Definition.Year == year && m.Definition.Month == month);

    public void Save(MonthlyRecord record)
    {
        var records = LoadAll().ToList();

        records.RemoveAll(m =>
            m.Definition.Year == record.Definition.Year
            && m.Definition.Month == record.Definition.Month
        );

        records.Add(record);
        Persist(records);
    }

    public void Delete(int year, int month)
    {
        var records = LoadAll().ToList();

        records.RemoveAll(m => m.Definition.Year == year && m.Definition.Month == month);

        Persist(records);
    }

    private void Persist(List<MonthlyRecord> records)
    {
        var dtos = records.Select(MonthlyRecordMapper.ToDto).ToList();

        var json = JsonSerializer.Serialize(
            dtos,
            new JsonSerializerOptions { WriteIndented = true }
        );

        Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);
        File.WriteAllText(_filePath, json);
    }
}
