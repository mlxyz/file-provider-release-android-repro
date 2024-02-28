namespace FileProviderReleaseRepro
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            var service = new FileHandlerService.FileHandlerService();
            service.Test();
        }
    }

}
