using System.Windows.Input;

namespace FocusedFlow.App.ViewModels;

public partial class ShellViewModel : ViewModelBase
{
    private object? _currentViewModel;
    public object? CurrentViewModel
    {
        get => _currentViewModel;
        private set
        {
            _currentViewModel = value;
            OnPropertyChanged();
        }
    }

    public ICommand ShowDailyCommand { get; }
    public ICommand ShowWeeklyCommand { get; }
    public ICommand ShowMonthlyCommand { get; }

    public ShellViewModel()
    {
        ShowDailyCommand = new RelayCommand(ShowDaily);
        ShowWeeklyCommand = new RelayCommand(ShowWeekly);
        ShowMonthlyCommand = new RelayCommand(ShowMonthly);

        ShowDaily();
    }

    private void ShowDaily()
    {
        CurrentViewModel = new DailyViewModel();
    }

    private void ShowWeekly()
    {
        CurrentViewModel = new WeeklyViewModel();
    }

    private void ShowMonthly()
    {
        CurrentViewModel = new MonthlyViewModel();
    }
}
