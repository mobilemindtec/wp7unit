wp7 unit
========

The project WP7 Unit is designed to provide a simple and fast way to build unit tests in Windows Phone development environment. Currently, it is an extremely simple design, which has the unique purpose of unit testing the level of business rule, or consistency of code, without giving importance to tests with graphical interface.


Test Case Class

Warning: The test should start with Test key word

     /// <summary>
    /// the test class should inherit of MobileMindWP7Unit.Unit.TestBehaviorImpl
    /// or implement MobileMindWP7Unit.Unit.ITestBehavior
    /// </summary>
    public class SimpleTest : MobileMindWP7Unit.Unit.TestBehaviorImpl
    {
        /// <summary>
        /// the test should start with Test key word
        /// </summary>
        public void TestFail()
        {
            this.Say("OK brother! ;)");
            this.Say("this test is faulted!");
            Assert.IsGreater(5, 6);
        }

        /// <summary>
        /// the test should start with Test key word
        /// </summary>
        public void TestSuccess()
        {
            this.Say("Hi guys");
            this.Say(@"this test can't fails /o/ \o/ \o\");
            Assert.IsLess(5, 6);
        }
    }



Configure Test Case in Main Page

Warnign: The Test Page should called in loaded event.

      // The Test Page should called in loaded event
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        //Add test case class and initializing page
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            TestSuite.AddTestCase<SimpleTest>();
            Uri uri = new Uri("/MobileMindWP7Unit;component/TestWebView.xaml", UriKind.Relative);
            NavigationService.Navigate(uri);          

        }

