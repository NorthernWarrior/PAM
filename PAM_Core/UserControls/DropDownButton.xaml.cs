using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PAM.UserControls
{
    /// <summary>
    /// Interaktionslogik für DropDownButton.xaml
    /// </summary>
    public partial class DropDownButton : Button
    {
        public static DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(ImageSource), typeof(DropDownButton), new PropertyMetadata(null));
        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(DropDownButton), new PropertyMetadata(null));
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public DropDownButton()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var bu = sender as Button;
            if (bu == null)
                throw new Exception("Button_Click in DropDownButton must be called by a Button!");

            if (bu.ContextMenu == null)
                return;

            bu.ContextMenu.IsEnabled = true;
            bu.ContextMenu.PlacementTarget = (sender as Button);
            bu.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            bu.ContextMenu.IsOpen = true;
        }
    }
}
