using FolderSync.Infrastructure;
using FolderSync.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FolderSync.ViewModels
{
    public class OperationViewModel : Infrastructure.ModelNotification
    {
        private string? _sourcePath;
        private string? _targetPath;
        private IList<FileModel> _fileList = new List<FileModel>();

        private ICommand _analyzeCmd;
        public ICommand AnalyzeCmd
        {
            get
            {
                if (_analyzeCmd == null) _analyzeCmd = new RelayCommand(p => OnAnalyze());
                return _analyzeCmd;
            }
        }

        private void OnAnalyze()
        {
            Console.WriteLine("OnAnalyze");
        }

        private ICommand _execCmd;
        public ICommand ExecCmd
        {
            get
            {
                if (_execCmd == null) _execCmd = new RelayCommand(p => OnExec());
                return _execCmd;
            }
        }

        private void OnExec()
        {
            Console.WriteLine("OnExec");
        }

        private ICommand _browseSourceCmd;
        public ICommand BrowseSourceCmd
        {
            get
            {
                if (_browseSourceCmd == null ) _browseSourceCmd = new RelayCommand(p => OnBrowseSource());
                return _browseSourceCmd;
            }
        }

        private void OnBrowseSource()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                var filename = dlg.FileName;
                SourcePath = Path.GetDirectoryName(filename);
                Console.WriteLine($"Dir: {SourcePath}");
            }
        }

        private ICommand _browseTargetCmd;
        public ICommand BrowseTargetCmd
        {
            get
            {
                if (_browseTargetCmd == null) _browseTargetCmd = new RelayCommand(p => OnBrowseTarget());
                return _browseTargetCmd;
            }
        }

        private void OnBrowseTarget()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                var filename = dlg.FileName;
                TargetPath = Path.GetDirectoryName(filename);
                Console.WriteLine($"Dir: {TargetPath}");
            }
        }

        public string SourcePath { get { return _sourcePath; } set { _sourcePath = value; OnPropertyChanged("SourcePath"); } }
        public string TargetPath { get { return _targetPath; } set { _targetPath = value; OnPropertyChanged("TargetPath"); } }
        public IList<FileModel> FileList { get { return _fileList; } set { _fileList = value; OnPropertyChanged("FileList"); } }

        
       
        public OperationViewModel()
        {
            _fileList.Clear();
            FileList.Add(new FileModel{ File = @"C:\temp", Code = 1, ModifiedDate = DateTime.Now.ToShortDateString() });
        }
    }
}
