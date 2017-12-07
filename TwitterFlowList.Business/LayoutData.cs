using System;
using System.Globalization;
using Xamarin.Forms;

namespace TwitterFlowList
{
	struct LayoutData
	{
		public int VisibleChildCount { get; private set; }

		public Size CellSize { get; private set; }

		public int Rows { get; private set; }

		public int Columns { get; private set; }

		public LayoutData(int visibleChildCount, Size cellSize, int rows, int columns) : this()
		{
			VisibleChildCount = visibleChildCount;
			CellSize = cellSize;
			Rows = rows;
			Columns = columns;
		}

	}

    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string valueAsString = value.ToString();
            switch (valueAsString)
            {
                case (""):
                    {
                        return Color.Default;
                    }
                case ("Accent"):
                    {
                        return Color.Accent;
                    }
                default:
                    {
                        return Color.FromHex(value.ToString());
                    }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}


