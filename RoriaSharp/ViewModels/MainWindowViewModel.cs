using System;
using RoriaSharp.Api.Generated;

namespace RoriaSharp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly ApiClient _apiClient;

    internal MainWindowViewModel()
    {
        throw new NotImplementedException("Default constructor should never be called");
    }
    
    public MainWindowViewModel(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }
}