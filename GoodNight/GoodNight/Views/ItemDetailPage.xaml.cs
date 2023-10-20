using GoodNight.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace GoodNight.Views
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