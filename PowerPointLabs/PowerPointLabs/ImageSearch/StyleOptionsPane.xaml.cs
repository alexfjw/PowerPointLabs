﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using PowerPointLabs.ImageSearch.Domain;
using PowerPointLabs.ImageSearch.Util;
using PowerPointLabs.Utils;
using Color = System.Drawing.Color;

namespace PowerPointLabs.ImageSearch
{
    /// <summary>
    /// Interaction logic for StyleOptionsPane.xaml
    /// </summary>
    public partial class StyleOptionsPane
    {
        public StyleOptionsPane()
        {
            InitializeComponent();
        }

        private void ColorPanel_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var panel = sender as Border;
            if (panel == null) return;

            var colorDialog = new ColorDialog
            {
                Color = GetColor(panel.Background as SolidColorBrush),
                FullOpen = true
            };
            if (colorDialog.ShowDialog() != DialogResult.OK) return;
            
            var hexString = StringUtil.GetHexValue(colorDialog.Color);
            var options = DataContext as StyleOptions;
            if (options == null) return;
            
            switch (panel.Name)
            {
                case "FontColorPanel":
                    options.FontColor = hexString;
                    break;
                case "OverlayColorPanel":
                    options.OverlayColor = hexString;
                    break;
            }
        }

        public Color GetColor(SolidColorBrush brush)
        {
            return Color.FromArgb(brush.Color.A, brush.Color.R, brush.Color.G, brush.Color.B);
        }

        private void ResetButton_OnClick(object sender, RoutedEventArgs e)
        {
            var options = DataContext as StyleOptions;
            if (options != null)
            {
                options.Init();
            }
        }
    }
}
