using HospitalUI.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace HospitalApplication.Infrastructure.Commands
{
    class DialogResultCommand : Command
    {
        public bool? DialogResult { get; set; }

        public override void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;

            var window = App.CurrentWindow;

            var dialog_result = DialogResult;

            if (parameter != null)
                dialog_result = (bool?)Convert.ChangeType(parameter, typeof(bool?));

            window.DialogResult = dialog_result;
            window.Close();
        }

        public override bool CanExecute(object parameter) => App.ActiveWindow != null;
    }
}
