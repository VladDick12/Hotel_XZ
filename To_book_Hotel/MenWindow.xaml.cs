using Newtonsoft.Json;
using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows;
using System.Windows.Controls;
using System.IO;
namespace To_book_Hotel
{
    public partial class MenWindow
    {
        public MenWindow()
        {
            InitializeComponent();
            calendar.SelectedDatesChanged += Calendar_SelectedDatesChanged;
            btn.Click += Button_Click;
            btn2.Click += Button_Click_1; // Добавляем обработчик события для второй кнопки
        }
        private DateTime startDate;
        private DateTime endDate;
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (calendar.SelectedDates.Count > 0)
            {
                startDate = calendar.SelectedDates[0];
                date.Text = startDate.ToString("dd/MM/yyyy");
            }

            if (calendar2.SelectedDates.Count > 1)
            {
                endDate = calendar2.SelectedDates[1];
                date2.Text = endDate.ToString("dd/MM/yyyy");
            }

            date.Text = startDate.ToString("dd/MM/yyyy");
            date2.Text = endDate.ToString("dd/MM/yyyy");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var selectedDate = calendar.SelectedDate;
            if (selectedDate.HasValue)
            {
                date.Text = selectedDate.Value.ToString("dd.MM.yyyy");


            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var selectedDate = calendar2.SelectedDate;
            if (selectedDate.HasValue)
            {
                date2.Text = selectedDate.Value.ToString("dd.MM.yyyy");


            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Создаем экземпляр UserData и заполняем данными из TextBox'ов
            UserData userData = new UserData
            {
                FirstName = name.Text,
                LastName = lastname.Text,
                NumberOfPeople = int.Parse(people.Text),
                CheckInDate = date.Text,
                CheckOutDate = date2.Text
            };
            string json = JsonConvert.SerializeObject(userData, Formatting.Indented);


            File.WriteAllText("UserData.json", json);

            MessageBox.Show("Данные успешно сохранены!");
        }
    }
}