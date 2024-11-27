using CommunityToolkit.Maui.Markup;

namespace MauiApp1.Pages;

// ReSharper disable once ClassNeverInstantiated.Global
public class SampleContentPage : ContentPage
{
    public SampleContentPage() =>
        Content = new Grid
        {
            RowDefinitions = GridRowsColumns.Rows.Define([(Row.TextEntry, 36)]),
            ColumnDefinitions = GridRowsColumns.Columns.Define(
            [
                (Column.Description, GridRowsColumns.Star),
                (Column.Input, GridRowsColumns.Stars(2))
            ]),
            Children =
            {
                new Label()
                    .Text("Code:")
                    .Row(Row.TextEntry).Column(Column.Description),
                new Entry { Keyboard = Keyboard.Numeric, }.Row(Row.TextEntry).Column(Column.Input)
                    .BackgroundColor(Colors.AliceBlue)
                    .FontSize(15)
                    .Placeholder("Enter number")
                    .TextColor(Colors.Black)
                    .Height(44)
                    .Margin(5, 5)
                    .Bind(Entry.TextProperty,
                        static vm => vm.RegistrationCode,
                        static (ViewModel vm, string text) => vm.RegistrationCode = text)
            }
        };

    private enum Row { TextEntry }

    private enum Column { Description, Input }
}

// ReSharper disable once ClassNeverInstantiated.Global
public class ViewModel
{
    public string RegistrationCode { get; set; } = string.Empty;
}
