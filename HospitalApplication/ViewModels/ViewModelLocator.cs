﻿using HospitalUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalApplication.ViewModels
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel 
		    => App.Services.GetRequiredService<MainWindowViewModel>();

    }
}
