using Prism.Mvvm;
using Prism.Commands;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Text;
using mascot.Models;

namespace mascot.ViewModels
{
    class browseButtonViewModel : BindableBase
    {
        #region property definition
        public ReactiveProperty<string> FilePath { get; set; } = new ReactiveProperty<string>("");
        public DelegateCommand browseButtonClicked { get; private set; }
        #endregion
        private IFileOpenService _fileOpen;

        public browseButtonViewModel(IFileOpenService fileOpen)
        {
            this._fileOpen = fileOpen;
            browseButtonClicked = new DelegateCommand(
                () =>
                {
                    if (_fileOpen.OpenFile())
                    {
                        FilePath.Value = _fileOpen.FileNames[0];
                    }
                },
                () => true);
        }
    }
}
