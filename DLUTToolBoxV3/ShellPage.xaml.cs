﻿// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using WinUICommunity.Common.ViewModel;
using DLUTToolBoxV3.Pages;
using DLUTToolBoxV3.Configurations;
using Castle.Core.Internal;
using Microsoft.Windows.AppNotifications.Builder;
using Microsoft.Windows.AppNotifications;
using WinUICommunity.Common.Helpers;
using Microsoft.UI.Xaml.Media.Animation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DLUTToolBoxV3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShellPage : Page
    {
        public ShellViewModel ViewModel { get; } = new ShellViewModel();
        public ShellPage()
        {
            this.InitializeComponent();
            ViewModel.InitializeNavigation(shellFrame, navigationView)
            .WithAutoSuggestBox(autoSuggestBox)
            .WithKeyboardAccelerator(KeyboardAccelerators)
            .WithDefaultPage(typeof(GeneralPage));
            if(ApplicationConfig.GetSettings("Uid").IsNullOrEmpty()|| ApplicationConfig.GetSettings("Password").IsNullOrEmpty())
            {
                var builder = new AppNotificationBuilder()
                    .AddText("请先在参数配置界面设置学工号和统一认证密码!\n设置完成后⚠重启本程序⚠方可正常使用所有功能！");
                var notificationManager = AppNotificationManager.Default;
                notificationManager.Show(builder.BuildNotification());
            }
        }
        private void UserControl_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.OnLoaded();
        }

        private void navigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            ViewModel.OnItemInvoked(args);
        }

        private void OnControlsSearchBoxQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            ViewModel.OnAutoSuggestBoxQuerySubmitted(args);
        }

        private void OnControlsSearchBoxTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (autoSuggestBox == null)
            {
                throw new NullReferenceException("AutoSuggestBox is null, please initialize ShellViewModel with a AutoSuggestBox.");
            }

            if (args.Reason != 0)
            {
                return;
            }

            List<string> list = new List<string>();
            List<NavigationViewItem> source = navigationView.MenuItems.OfType<NavigationViewItem>().ToList();
            string[] querySplit = autoSuggestBox.Text.Split(' ');
            foreach (NavigationViewItem item in source.Where(delegate (NavigationViewItem item)
            {
                bool result = true;
                string[] array = querySplit;
                foreach (string value in array)
                {
                    if (item.Content.ToString()!.IndexOf(value, StringComparison.CurrentCultureIgnoreCase) < 0)
                    {
                        result = false;
                    }
                }

                return result;
            }))
            {
                list.Add(item.Content.ToString());
            }

            if (list.Count > 0)
            {
                autoSuggestBox.ItemsSource = list;
                return;
            }

            autoSuggestBox.ItemsSource = new string[1] { "未找到匹配的结果" };
        }
    }
}
