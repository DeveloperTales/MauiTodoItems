namespace TodoItems.Views.CutomViews;

public class BindableToolbarItem : ToolbarItem
{
    private IList<ToolbarItem> ToolbarItems { get; set; }

    public static readonly BindableProperty IsVisibleProperty =
        BindableProperty.Create(nameof(IsVisible), typeof(bool), typeof(BindableToolbarItem), true, BindingMode.OneWay, propertyChanged: OnIsVisibleChanged);

    public bool IsVisible
    {
        get => (bool)GetValue(IsVisibleProperty);
        set => SetValue(IsVisibleProperty, value);
    }

    private static void OnIsVisibleChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var item = (BindableToolbarItem)bindable;

        item.RefreshVisibility();
    }

    protected override void OnParentChanged()
    {
        base.OnParentChanged();

        var parentToolbarItems = (Parent as ContentPage)?.ToolbarItems;

        if (parentToolbarItems is not null)
        {
            ToolbarItems = parentToolbarItems;
        }

        RefreshVisibility();
    }

    private void RefreshVisibility()
    {
        if (ToolbarItems is null)
        {
            return;
        }

        bool value = IsVisible;

        if (value && !ToolbarItems.Contains(this))
        {
            Application.Current!.Dispatcher.Dispatch(() => { ToolbarItems.Add(this); });
        }
        else if (!value && ToolbarItems.Contains(this))
        {
            Application.Current!.Dispatcher.Dispatch(() => { ToolbarItems.Remove(this); });
        }
    }
}
