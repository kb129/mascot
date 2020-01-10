using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace mascot.Models
{
    public interface IFileOpenService
    {
        /// <summary>
        /// Open File
        /// </summary>
        /// <returns>True if file selected</returns>
        bool OpenFile();

        /// <summary>
        /// Full names of the selected files
        /// </summary>
        string[] FileNames { get; }
    }

    public class FileOpenService : IFileOpenService
    {
        OpenFileDialog _openFileDialog = new OpenFileDialog();
        string[] _selectedFileNames;

        public bool OpenFile()
        {
            _openFileDialog.Multiselect = true;
            var ofd = _openFileDialog.ShowDialog();
            if (ofd == DialogResult.OK || ofd == DialogResult.Yes)
            {
                _selectedFileNames = _openFileDialog.FileNames;
                return true;
            }
            return false;
        }

        public string[] FileNames
        {
            get { return _selectedFileNames; }
        }
    }
}
