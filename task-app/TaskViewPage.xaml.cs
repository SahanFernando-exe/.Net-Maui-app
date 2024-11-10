namespace task_app;

public partial class TaskViewPage : ContentPage
{
	public TaskViewPage()
	{
		InitializeComponent();
	}

    private void clickev(object sender, EventArgs e)
    {
        List<Task> tasks = Task.allTasks();
    }

    private async void Add_Task_Button(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}