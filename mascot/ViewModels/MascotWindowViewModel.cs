using Prism.Mvvm;
using Prism.Services.Dialogs;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using Reactive.Bindings;

namespace mascot.ViewModels
{
    class MascotWindowViewModel : BindableBase, IDialogAware
    {
        public ReactiveProperty<string> ModelPath { get; set; } = new ReactiveProperty<string>("");

        public ReactiveProperty<string> MotionPath { get; set; } = new ReactiveProperty<string>("");

        public string Title => "MascotWindow";

        public MascotWindowViewModel()
        {

        }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            ModelPath.Value = parameters.GetValue<string>("strModelPath");
            MotionPath.Value = parameters.GetValue<string>("strMotionPath");
            // ここに表示させるための処理を記述
            
        }
    }
}
