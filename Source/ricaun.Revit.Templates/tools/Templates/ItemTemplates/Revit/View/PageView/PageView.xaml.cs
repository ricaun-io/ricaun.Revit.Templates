using System;
using System.Windows;
using System.Windows.Controls;

namespace $rootnamespace$
{
    public partial class $safeitemname$
    {
        public $safeitemname$(Page page = null)
        {
            InitializeComponent();
            InitializeWindow();
            Frame.Content = page;
            Title = page?.Title;
        }

#region InitializeWindow
        private void InitializeWindow()
        {
            this.MinHeight = 480;
            this.MinWidth = 480;
            this.Height = MinHeight;
            this.Width = MinWidth;
            this.ShowInTaskbar = false;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            new System.Windows.Interop.WindowInteropHelper(this) { Owner = Autodesk.Windows.ComponentManager.ApplicationWindow };
        }
#endregion
    }
}