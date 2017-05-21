using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SecondTooltipTrouble
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            ToolTip myToolTip = new ToolTip
            {
                StaysOpen = false,
                Placement = PlacementMode.Custom,
                CustomPopupPlacementCallback = (toolTipSz, targetSz, offset) =>
                {
                    return new[]
                    {
                        new CustomPopupPlacement(new Point(10, 10), PopupPrimaryAxis.Horizontal)
                    };
                },
                PlacementTarget = sender as UIElement,
                Content = sender.GetType()
                                .ToString(),
                IsOpen = true
            };
        }
    }
}
