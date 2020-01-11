using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Reactive.Disposables;
using mascot.Views;

namespace mascot.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public ReactiveProperty<string> ModelPath { get; set; } = new ReactiveProperty<string>("");
        public ReactiveProperty<string> MotionPath { get; set; } = new ReactiveProperty<string>("");
        public ReactiveCommand ShowMascotCommand { get; } = new ReactiveCommand();

        private readonly CompositeDisposable _disposeCollection = new CompositeDisposable();

        public MainWindowViewModel(IDialogService dialogService)
        {
            ShowMascotCommand.Subscribe(() =>
            {
                IDialogResult result = null;
                dialogService.Show(nameof(MascotWindow), new DialogParameters { { "strModelPath", ModelPath.Value }, { "strMotionPath", MotionPath.Value } }, r => result = r);
            }).AddTo(_disposeCollection);
        }
    }
}
