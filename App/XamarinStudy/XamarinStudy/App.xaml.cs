﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinStudy.Pages;

namespace XamarinStudy
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Pages.MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
