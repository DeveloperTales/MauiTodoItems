using TodoItems.Views;

namespace TodoItems;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("todoItem", typeof(TodoItemPage));
    }
}
