using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using MobileMindWP7Unit.Unit;

namespace MobileMindWP7Unit
{
    public partial class TestWebView : PhoneApplicationPage
    {

        public bool ShowProgress
        {
            get { return (bool)GetValue(ShowProgressProperty); }
            set { SetValue(ShowProgressProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowProgress.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowProgressProperty =
            DependencyProperty.Register("ShowProgress", typeof(bool), typeof(TestWebView), new PropertyMetadata(false));



        public TestWebView()
        {
            InitializeComponent();
            this.webBrowser.Visibility = System.Windows.Visibility.Collapsed;
            this.Loaded += delegate
                               {                                   
                                   LoadProgressBar();                                   
                                   new Thread(new ThreadStart(Init)).Start();
                               };
        }

        private void LoadProgressBar()
        {
            ShowProgress = true;
        }


        private void Init()
        {
            TestSuite.RunTestSuite();
            String htmlFileLocation = null;
            htmlFileLocation = TestSuite.PrintTestsResults();

            String htmlFile = htmlFileLocation;
            Uri uri = null;

            if (htmlFile == null)
            {
                uri = new Uri("http://www.mobilemind.com.br");                
            }
            else
            {
                uri = new Uri(htmlFile, UriKind.Relative);
            }

            Thread.Sleep(TimeSpan.FromSeconds(3));

            this.Dispatcher.BeginInvoke(
                () =>
                    {
                        this.webBrowser.Navigate(uri);
                        ShowProgress = false;
                        this.webBrowser.Visibility = System.Windows.Visibility.Visible;
                    });
        }
    }
}