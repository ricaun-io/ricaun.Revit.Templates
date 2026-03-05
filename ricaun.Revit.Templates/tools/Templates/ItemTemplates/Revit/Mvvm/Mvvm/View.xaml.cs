using System;
using System.Windows;

namespace $rootnamespace$.Views
{
    public partial class $safeitemname$
    {
        public $safeitemname$()
        {
            InitializeComponent();
            InitializeWindow();
        }

#region InitializeWindow
        private void InitializeWindow()
        {
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.ShowInTaskbar = false;
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
#endregion
    }
}