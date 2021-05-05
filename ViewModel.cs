using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WpfApp10
{
  public class ViewModel: INotifyPropertyChanged
    {
       
        private string urlSize;
        private bool isEnable;
        private double watch;
        public double Watch
        {
            get
            {
                return watch;
            }
            set
            {
                watch = value;
                OnPropertyChanged("Watch");
            }
        }
        public bool IsEnable
        {
            get
            {
                return isEnable;
            }
            set
            {
                isEnable = value;
                OnPropertyChanged("isEnable");
            }
        }
        private string loading;
        public string Loading
        {
            get
            {
                return loading;
            }
            set
            {
                loading = value;
                OnPropertyChanged("Loading");
            }
        }
        public string Url { get; set; }
        public string UrlSize
        {
            get
            {
                return urlSize;
            }
            set
            {
                urlSize = value;
                OnPropertyChanged("urlSize");
            }
        }
        public DelegateCommand MyDelegateDistpatcher { get; set; }
        public DelegateCommand MyDelegateAsync { get; set; }

        public ViewModel()
        {
            InitializeData(); 
        }
        private void InitializeData()
        {
            MyDelegateAsync = new DelegateCommand(GetUrlSizeAync, CanExecuteMethod);
            MyDelegateDistpatcher = new DelegateCommand(GetUrlSizeAync, CanExecuteMethod);
            Loading = "";
            Url = "http://";
            isEnable = true;
        }
        public async void GetUrlSizeAync()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            isEnable = false;
            Loading = "Loading....";
            try
            {
                WebRequest webRequest = WebRequest.Create(Url);
                WebResponse response = await webRequest.GetResponseAsync();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string text = await reader.ReadToEndAsync();
                    UrlSize = text.Length.ToString();
                }
            }
           catch(Exception e)
            {
                MessageBox.Show($"The URL Address is invalid try again , Error:{e}");
            }
            finally
            {
                isEnable = true;
                Loading = "";
                sw.Stop();
                Watch = sw.ElapsedMilliseconds;
            }
        }

        public void GetUrlSizeDispatcher()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            isEnable = false;
            Loading = "Loading....";
            Task.Run(() =>
            {
                try
                {
                    WebRequest webRequest = WebRequest.Create(Url);
                    WebResponse response = webRequest.GetResponse();
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string text = reader.ReadToEnd();
                        Dispatcher.CurrentDispatcher.Invoke(() => { UrlSize = text.Length.ToString(); });
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"The Url is invalid try again, Error:{e}");
                }
                finally
                {
                    sw.Stop();
                    isEnable = true;
                    Loading = "";
                    Watch = sw.ElapsedMilliseconds;
                }
            });
           
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs($"{property}"));
            }
        }
        private bool CanExecuteMethod()
        {
            if (isEnable && !string.IsNullOrEmpty(Url))
                return true;
            else
                return false;
        }

    
    }
}