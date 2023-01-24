using TodoItems.Views;

namespace TodoItems;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("quote", typeof(QuotePage));
        Routing.RegisterRoute("todoItem", typeof(TodoItemPage));
    }
}
