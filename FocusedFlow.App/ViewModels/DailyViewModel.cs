using System;
using FocusedFlow.Core.Daily;

namespace FocusedFlow.App.ViewModels;

public sealed class DailyViewModel : ViewModelBase
{
    private readonly DailyRecord _record;
    private readonly DailyEvaluator _evaluator;
    private DailyOutcome? _outcome;

    private double _sleepHours;
    private double _waterLiters;
    private int _mealsCount;

    public DailyViewModel()
    {
        _record = new DailyRecord(DateOnly.FromDateTime(DateTime.Today));
        _evaluator = new DailyEvaluator();

        Reevaluate();
    }

    public double SleepHours
    {
        get => _sleepHours;
        set
        {
            if (_sleepHours == value) return;

            _sleepHours = value;
            UpdateBaseline();
            OnPropertyChanged();
        }
    }

    public double WaterLiters
    {
        get => _waterLiters;
        set
        {
            if (_waterLiters == value) return;

            _waterLiters = value;
            UpdateBaseline();
            OnPropertyChanged();
        }
    }

    public int MealsCount
    {
        get => _mealsCount;
        set
        {
            if (_mealsCount == value) return;

            _mealsCount = value;
            UpdateBaseline();
            OnPropertyChanged();
        }
    }

    private void UpdateBaseline()
    {
        _record.UpdateBaseline(
            sleepHours: _sleepHours,
            waterLiters: _waterLiters,
            mealsCount: _mealsCount
        );

        Reevaluate();
    }
    public string AnchorName => "Anchor Activity";

    public string AnchorStatus => IsDayPassed ? "Completed" : "Pending";

    public void CompleteAnchor()
    {
        _record.CompleteAnchor();
        Reevaluate();
    }

    public void ResetAnchor()
    {
        _record.ResetAnchor();
        Reevaluate();
    }

    public bool IsDayPassed => _outcome?.Passed ?? false;

    private void Reevaluate()
    {
        _outcome = _evaluator.Evaluate(_record);

        OnPropertyChanged(nameof(IsDayPassed));
        OnPropertyChanged(nameof(AnchorStatus));
    }
}
