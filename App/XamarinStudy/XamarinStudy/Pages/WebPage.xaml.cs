using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinStudy.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebPage : ContentPage
    {
        public WebPage()
        {
            InitializeComponent();
        }


        public void OnLoadUrlClicked(object sender, EventArgs e)
        {
            string Url = EditorUrl.Text;

            WebView.Source = Url;
        }
    }
}