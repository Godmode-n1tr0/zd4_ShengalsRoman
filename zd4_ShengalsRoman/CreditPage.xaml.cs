using System;
using Xamarin.Forms;

namespace zd4_ShengalsRoman
{
    public partial class CreditPage : ContentPage
    {
        public CreditPage()
        {
            InitializeComponent();
            paymentTypePicker.SelectedIndex = 0;
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            rateLabel.Text = $"{Math.Round(e.NewValue)}%";
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            if (!double.TryParse(amountEntry.Text, out double amount) ||
                !int.TryParse(monthsEntry.Text, out int months))
            {
                DisplayAlert("Ошибка", "Введите корректные значения", "OK");
                return;
            }

            double rate = rateSlider.Value / 100;
            string type = paymentTypePicker.SelectedItem?.ToString();

            if (type == "Аннуитетный")
            {
                double monthlyRate = rate / 12;
                double monthlyPayment = (amount * monthlyRate) /
                    (1 - Math.Pow(1 + monthlyRate, -months));
                double total = monthlyPayment * months;
                double overpay = total - amount;

                monthlyLabel.Text = $"Ежемесячный платёж: {monthlyPayment:F2} ₽";
                totalLabel.Text = $"Общая сумма: {total:F2} ₽";
                overpayLabel.Text = $"Переплата: {overpay:F2} ₽";
            }
            else
            {
                // Скрываем аннуитетный платёж
                monthlyLabel.Text = $"Ежемесячный платёж: — (только для аннуитетного)";
                totalLabel.Text = $"—";
                overpayLabel.Text = $"—";
            }
        }
    }
}
