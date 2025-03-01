﻿// Copyright (c) Richasy. All rights reserved.

using System;
using CleanReader.ViewModels.Desktop;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.System;

namespace CleanReader.App.Controls
{
    /// <summary>
    /// Ambie 集成设置.
    /// </summary>
    public sealed partial class AmbieSettingItem : UserControl
    {
        private readonly BackgroundMusicViewModel _viewModel = BackgroundMusicViewModel.Instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="AmbieSettingItem"/> class.
        /// </summary>
        public AmbieSettingItem()
        {
            InitializeComponent();
            Loaded += OnLoadedAsync;
            Unloaded += OnUnloaded;
        }

        private async void OnLoadedAsync(object sender, RoutedEventArgs e)
        {
            await _viewModel.CheckAmbieInstalledAsync();
            AppViewModel.Instance.MainWindow.Activated += OnWindowActivatedAsync;
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
            => AppViewModel.Instance.MainWindow.Activated -= OnWindowActivatedAsync;

        private async void OnWindowActivatedAsync(object sender, WindowActivatedEventArgs args)
            => await _viewModel.CheckAmbieInstalledAsync();

        private async void OnDownloadLinkClickAsync(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("ms-windows-store://pdp/?productid=9P07XNM5CHP0");
            await Launcher.LaunchUriAsync(uri);
        }
    }
}
