using System.ComponentModel;
using TestProject.ViewModels;
using Xamarin.Forms;

namespace TestProject.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}