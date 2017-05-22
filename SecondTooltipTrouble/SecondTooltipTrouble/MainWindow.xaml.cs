using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace SecondTooltipTrouble
{
    public partial class MainWindow : Window
    {
        private readonly List<ToolTip> _toolTips = new List<ToolTip>();

        public MainWindow()
        {
            InitializeComponent();

            _toolTips = new List<ToolTip>
            {
                new ToolTip
                {
                    StaysOpen = false,
                    Placement = PlacementMode.Custom,
                    CustomPopupPlacementCallback = (toolTipSz, targetSz, offset) =>
                    {
                        return new[] { new CustomPopupPlacement(new Point(10, 10), PopupPrimaryAxis.Horizontal) };
                    },
                    PlacementTarget = Button,
                    Content = "Any text",
                },
                new ToolTip
                {
                    StaysOpen = false,
                    Placement = PlacementMode.Custom,
                    CustomPopupPlacementCallback = (toolTipSz, targetSz, offset) =>
                    {
                        return new[] { new CustomPopupPlacement(new Point(10, 10), PopupPrimaryAxis.Horizontal) };
                    },
                    PlacementTarget = TextBlock,
                    Content = "Any text",
                },
            };
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var toolTip in _toolTips)
            {
                toolTip.IsOpen = true;
            }
        }

        private void OnButtonLostFocus(object sender, RoutedEventArgs e)
        {
            foreach (var toolTip in _toolTips)
            {
                toolTip.IsOpen = false;
            }
        }

        private void OnLayoutRootMouseDown(object sender, RoutedEventArgs e)
        {
            FocusManager.SetFocusedElement(this, LayoutRoot);
        }
    }
}
