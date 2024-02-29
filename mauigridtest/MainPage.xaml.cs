using System.Diagnostics;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace mauigridtest;

public partial class MainPage : ContentPage
{
    int count = 0;

    double windowWidth = Application.Current.MainPage.Width;
    double windowHeight = Application.Current.MainPage.Height;

    public delegate void ActionOnCompleted(char col, int row);

    public MainPage()
    {
        InitializeComponent();
        PopulateGrid(10, 10);

    }

    //
    // private void OnCounterClicked(object sender, EventArgs e)
    // {
    //     count++;
    //
    //     if (count == 1)
    //         CounterBtn.Text = $"Clicked {count} time";
    //     else
    //         CounterBtn.Text = $"Clicked {count} times";
    //
    //     SemanticScreenReader.Announce(CounterBtn.Text);
    // }
    private void PopulateGrid(int rows, int columns)
    {
        
        Application.Current.UserAppTheme = AppTheme.Light; // Set the default theme to light

        var colWidth = windowWidth*0.9/columns;
        var rowHeight = windowHeight*0.9/rows;
        // Add the column labels row
        var headerRow = new HorizontalStackLayout();
        headerRow.Add(new Label
        {
            Text = " ", // Placeholder for the top-left corner cell
            WidthRequest = colWidth,
            HeightRequest = rowHeight,
            BackgroundColor = Colors.LightGray, // Example formatting
            HorizontalTextAlignment = TextAlignment.Center,
            VerticalTextAlignment = TextAlignment.Center,
        });

        for (int column = 1; column <= columns; column++)
        {
            headerRow.Add(new Label
            {
                Text = $"{(char)(column+64)}",
                WidthRequest = colWidth,
                HeightRequest = rowHeight,
                BackgroundColor = Colors.LightGray, // Example formatting
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
            });
        }

        mainLayout.Add(headerRow);

        // Add rows with row labels and data cells
        for (int row = 1; row <= rows; row++)
        {
            var rowLayout = new HorizontalStackLayout();

            // Add the row label
            rowLayout.Add(new Label
            {
                Text = $"{row}",
                WidthRequest = colWidth,
                HeightRequest = rowHeight,
                BackgroundColor = Colors.LightGray, // Matching formatting with column labels
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
            });

            // Add the data cells
            for (int column = 1; column <= columns; column++)
            {
                var cell = new MyEntry(row, handleCellChanged);
                cell.WidthRequest = colWidth;
                cell.HeightRequest = rowHeight;
                rowLayout.Add(cell);
            }

            mainLayout.Add(rowLayout);
        }
    }


    void handleCellChanged(char col, int row)
    {
        Debug.WriteLine($"changed: {col}{row}");
    }
}