namespace ScrollToAsyncTest
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();



        }

        private void Button_OnClicked(object? sender, EventArgs e)
        {
            MainThread.InvokeOnMainThreadAsync(async () =>
            {
                // Code should scroll to Button66 row, but on iOS scroll to the row and moves the grid to the right
                await TestScrollView.ScrollToAsync(Button66, ScrollToPosition.MakeVisible, false);

                if (DeviceInfo.Platform == DevicePlatform.iOS)
                {
                    // workaround for MAUI makevisible BUG where scrolling scoresheet to the right when scrol performed
                    await TestScrollView.ScrollToAsync(0, TestScrollView.ScrollY, false);
                }
            });
        }
    }

}
