using System;
using Avalonia.Controls;
using RoriaSharp.ViewModels;

namespace RoriaSharp.Views;

public partial class MainWindow : Window
{
    internal MainWindow()
    {
        throw new NotImplementedException("Default constructor should never be called");
    }
    
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}