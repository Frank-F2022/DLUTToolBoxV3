// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using DLUTToolBoxV3.Entities;
using DLUTToolBoxV3.Helpers;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DLUTToolBoxV3.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StudyPage : Page
    {
        public NLog.Logger logger;
        public StudyPage()
        {
            logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Info("��ѧϰ����ҳ��");
            this.InitializeComponent();
        }

        private void WeekTimeTable_Click(object sender, RoutedEventArgs e)
        {
            WebHelper.AddOrCreateNewPage(new AppDataItem("1", "���ܿα�", "ms-appx:///Assets/AppIcons/Study/WeekTimeTable.png", "", "https://api.m.dlut.edu.cn/login?client_id=9qXqHnRQuhhViycC&redirect_uri=https%3a%2f%2flightapp.m.dlut.edu.cn%2fcheck%2fcourseschedule&response_type=code", 0));
        }

        private void MyTimeTable_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClassTimeTable_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProgramCompletion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PublicNotice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CourseSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SpareClassroom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LeaveSchool_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
