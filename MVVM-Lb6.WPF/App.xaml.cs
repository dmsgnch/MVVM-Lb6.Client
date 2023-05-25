using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVM_Lb6.ViewModels;
using MVVM_Lb6.Views;
using MVVM_Lb6.Views.Main;

namespace MVVM_Lb6;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<HotelViewModel>();
                services.AddSingleton<LoginViewModel>();
                
                services.AddSingleton<LoginWindow>((services) => new LoginWindow()
                {
                    DataContext = services.GetRequiredService<LoginViewModel>()
                });
            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();

        MainWindow = _host.Services.GetRequiredService<LoginWindow>();
        MainWindow.Show();

        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _host.StopAsync();
        _host.Dispose();

        base.OnExit(e);
    }
}