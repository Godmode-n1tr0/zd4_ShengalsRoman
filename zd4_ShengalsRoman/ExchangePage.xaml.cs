using System;
using Xamarin.Forms;

namespace zd4_ShengalsRoman
{
    public partial class ExchangePage : ContentPage
    {
        public ExchangePage()
        {
            InitializeComponent();
            dateLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
