using System.Text.Json;
using FocusedFlow.Core.Daily;
using FocusedFlow.Persistence.Abstraction;
using FocusedFlow.Persistence.Mappers;
using FocusedFlow.Persistence.Models;

namespace FocusedFlow.Persistence.Json;

public sealed class JsonDailyRecordRepository(string filepath) : IDailyRecordRepository
{
    private JsonSerializerOptions _jsOptions = new JsonSerializerOptions { WriteIndented = true };
    private readonly string _filepath = filepath;

    public IReadOnlyList<DailyRecord> LoadAll()
    {
        if (!File.Exists(_filepath))
            return new List<DailyRecord>();

        var json = File.ReadAllText(_filepath);
        var dtos = JsonSerializer.Deserialize<List<DailyRecordDto>>(json) ?? []; // the [] means new() but empty which is the defualt for new List<>()

        return dtos.Select(DailyRecordMapper.FromDto).ToList();
    }

    public DailyRecord? Load(DateOnly date)
    {
        return LoadAll().FirstOrDefault(r => r.Date == date);
    }

    public void Save(DailyRecord record)
    {
        var records = LoadAll().ToList();

        records.RemoveAll(r => r.Date == record.Date);
        records.Add(record);

        Persist(records);
    }

    public void Delete(DateOnly date)
    {
        var records = LoadAll().ToList();
        records.RemoveAll(r => r.Date == date);

        Persist(records);
    }

    private void Persist(List<DailyRecord> records)
    {
        var dtos = records.Select(DailyRecordMapper.ToDto).ToList();
        var json = JsonSerializer.Serialize(dtos, _jsOptions);

        Directory.CreateDirectory(Path.GetDirectoryName(_filepath)!);
        File.WriteAllText(_filepath, json);
    }
}
