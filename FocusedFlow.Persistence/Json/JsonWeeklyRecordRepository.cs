using System.Text.Json;
using FocusedFlow.Core.Weekly;
using FocusedFlow.Persistence.Abstractions;
using FocusedFlow.Persistence.Mappers;
using FocusedFlow.Persistence.Models;

namespace FocusedFlow.Persistence.Json;

public sealed class JsonWeeklyRecordRepository(string filepath) : IWeeklyRecordRepository
{
    private readonly string _filePath = filepath;

    public IReadOnlyList<WeeklyRecord> LoadAll()
    {
        if (!File.Exists(_filePath))
            return [];

        var json = File.ReadAllText(_filePath);
        var dtos = JsonSerializer.Deserialize<List<WeeklyRecordDto>>(json) ?? [];

        return dtos.Select(WeeklyRecordMapper.FromDto).ToList();
    }

    public WeeklyRecord? Load(DateOnly weekStart) =>
        LoadAll().FirstOrDefault(w => w.WeekStart == weekStart);

    public void Save(WeeklyRecord record)
    {
        var records = LoadAll().ToList();

        records.RemoveAll(r => r.WeekStart == record.WeekStart);
        records.Add(record);

        Persist(records);
    }

    public void Delete(DateOnly weekStart)
    {
        var records = LoadAll().ToList();
        records.RemoveAll(r => r.WeekStart == weekStart);

        Persist(records);
    }

    private void Persist(List<WeeklyRecord> records)
    {
        var dtos = records.Select(WeeklyRecordMapper.ToDto).ToList();

        var json = JsonSerializer.Serialize(
            dtos,
            new JsonSerializerOptions { WriteIndented = true }
        );

        Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);

        File.WriteAllText(_filePath, json);
    }
}
