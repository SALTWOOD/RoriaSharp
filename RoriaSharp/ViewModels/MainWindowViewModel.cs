using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using RoriaSharp.Api.Generated;

namespace RoriaSharp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly ApiClient _apiClient;

    [ObservableProperty]
    private ViewModelBase _currentPage;

    [ObservableProperty]
    private int _selectedPageIndex;

    public ObservableCollection<NavigationItem> NavigationItems { get; }

    internal MainWindowViewModel()
    {
        throw new NotImplementedException("Default constructor should never be called");
    }

    public MainWindowViewModel(
        ApiClient apiClient,
        HomeViewModel homeViewModel,
        TunnelsViewModel tunnelsViewModel)
    {
        _apiClient = apiClient;
        _currentPage = homeViewModel;

        NavigationItems = new ObservableCollection<NavigationItem>
        {
            new(homeViewModel, HomeViewModel.Label, HomeViewModel.Icon),
            new(tunnelsViewModel, TunnelsViewModel.Label, TunnelsViewModel.Icon),
        };
    }

    partial void OnSelectedPageIndexChanged(int value)
    {
        if (value >= 0 && value < NavigationItems.Count)
        {
            CurrentPage = NavigationItems[value].ViewModel;
        }
    }
}

public class NavigationItem
{
    public ViewModelBase ViewModel { get; }
    public string Label { get; }
    public string Icon { get; }

    public NavigationItem(ViewModelBase viewModel, string label, string icon)
    {
        ViewModel = viewModel;
        Label = label;
        Icon = icon;
    }
}
