using Microsoft.Maui.Controls.Shapes;

namespace task_app
{
    public partial class MainPage : ContentPage
    {
        int cnt = 0;

        public MainPage()
        {
            InitializeComponent();
            CalendarGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            CalendarGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            CalendarGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            CalendarGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            CalendarGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            CalendarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            CalendarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            CalendarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            CalendarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            CalendarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            CalendarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            CalendarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
        }


        private void OnCounterClicked(object sender, EventArgs e)
        {
            CalendarGrid.Children.Clear();
            cnt++;
            int[,,] CalList = new int[12,6,7];
            int year = 2024;

            for (int month = 0; month < CalList.GetLength(0); month++)
            {
                int count = 0;
                int start_day = (int)new DateTime(2024, month+1, 1).DayOfWeek -1;
                if (start_day == -1) { start_day = 6; }
                int month_days = DateTime.DaysInMonth(2024, month+1);
                int last_month = month;
                if(month == 0) {last_month = DateTime.DaysInMonth(year - 1, 12); }
                else {last_month = DateTime.DaysInMonth(year, month); }
                Console.WriteLine($"{start_day} {last_month}");
                for (int day = last_month-start_day+1; day < last_month+1; day++)
                {
                    count++;
                    CalList[month, 0, count-1] = day;
                }
                for (int day = 1; day < month_days + 1; day++)
                {
                    count++;
                    int week_day = (count-1) % 7;
                    int week = (count - 1) / 7;
                    CalList[month, week, week_day] = day;
                    //Console.WriteLine(count + "  filled " + day);
                }
                for (int day = 1; day < 6*7 - month_days - start_day + 1; day++)
                {
                    count++;
                    int week_day = (count-1) % 7;
                    int week = (count -1) / 7;
                    CalList[month, week, week_day] = day;
                    //Console.WriteLine(count + "  end " + day);
                }
            }

            //foreach(int i in CalList) { Console.WriteLine(i); }

            for (int day=1; day < 42 + 1; day++)
            {
                int week_day = (day-1) % 7;
                int week = (day-1)/7;
                Grid day_template = new Grid();
                day_template.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                day_template.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                day_template.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                day_template.Add(new Label { Text = Convert.ToString(CalList[cnt,week,week_day]) }, 0, 0);
                CalendarGrid.Add(day_template, week_day, week + 1);
                CalendarGrid.Add(new Button { BackgroundColor = Colors.Transparent},week_day, week+1);
            }


            if (cnt == 1)
                CounterBtn.Text = $"Clicked {cnt} time";
            else
                CounterBtn.Text = $"Clicked {cnt} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
