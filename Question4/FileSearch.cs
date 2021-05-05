using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace WpfApp12
{
    public class FileSearch : INotifyPropertyChanged
    {
        private string txtpath;
        private string txt_contains_word;
        private bool isIndeterminate;
        private List<string> viewList;
        private bool isEnabled;

        public List<string> ViewList
        {
            get
            {
                return viewList;
            }
            set
            {
                viewList = value;
                OnPropertyChanged("ViewList");
            }
        }
        private List<string> tempList;
        public List<string> TempList
        {
            get
            {
                return tempList;
            }
            set
            {
                tempList = value;
                OnPropertyChanged("TempList");
            }
        }
        public bool IsIndeterminate
        {
            get
            {
                return isIndeterminate;
            }
            set
            {
                isIndeterminate = value;
                OnPropertyChanged("IsIndeterminate");
            }
        }
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }
        public DelegateCommand FolderDialogBtn { get; set; }
        public DelegateCommand FindFilesBtn { get; set; }

        public string TxtWord
        {
            get
            {
                return txt_contains_word;
            }
            set
            {
                txt_contains_word = value;
                OnPropertyChanged("TxtWord");
            }
        }
        public string TxtPath
        {
            get
            {
                return txtpath;
            }
            set
            {
                txtpath = value;
                OnPropertyChanged("TxtPath");
            }
        }
        public FileSearch()
        {
            FindFilesBtn = new DelegateCommand(StartFindFiles);
            FolderDialogBtn = new DelegateCommand(FolderDialog);
            TxtPath = "";
            TxtWord = "";
            ViewList = new List<string>();
            TempList = new List<string>();
            IsIndeterminate = false;
            isEnabled = true;
        }
        public void FolderDialog()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (!string.IsNullOrEmpty(result.ToString()))
            {
                TxtPath = dialog.SelectedPath;
            }
        }

        public async void StartFindFiles()
        {
            IsIndeterminate = true;
            isEnabled = false;
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
                FindFiles(TxtPath);
            });
            IsIndeterminate = false;
            isEnabled = true;
            if (ViewList.Count == 0)
            {
                MessageBox.Show("No files found");
            }

        }

        public  void FindFiles(string textPath)
        {
           
            string[] files = Directory.GetFiles(textPath);
            foreach (var item in files)
            {
                if (item.Contains(TxtWord))
                {
                    TempList.Add(item);
                    Dispatcher.CurrentDispatcher.Invoke(() => { ViewList = TempList; });      
                }
            }

            // search which files match the serach pattern
            // add this files into the list box (dispatcher or async/await)

            string[] folders = Directory.GetDirectories(textPath);
            foreach (var item in folders)
            {
                FindFiles(item);
            }
                
          
            

        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs($"{property}"));
            }
        }
    }
}
