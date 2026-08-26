using $rootnamespace$.Views;
using $rootnamespace$.Models;
using ricaun.Revit.Mvvm;
using ricaun.Revit.UI;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace $rootnamespace$.ViewModels
{
    public class $safeitemname$ : ObservableObject
    {
        #region Public Properties
        public ObservableCollection<$fileinputname$Model> Models { get; } = new();
        public IRelayCommand Command => new RelayCommand(AddModel);
        #endregion

        #region Constructor
        public $safeitemname$()
        {
            
        }
        #endregion

        #region View / Window
        public string Title { get; set; } = "$safeitemname$";
        public $fileinputname$View Window { get; private set; }
        public void Show()
        {
            if (Window is null)
            {
                Window = new $fileinputname$View();
                Window.DataContext = this;
                Window.SetAutodeskOwner();
                Window.Closed += (s, e) => { Window = null; };
            }
            Window?.Show();
            Window?.Activate();
        }
        #endregion

        #region Private Methods
        private void AddModel()
        {
            Models.Add(new $fileinputname$Model() { Name = $"{Guid.NewGuid()}" });
        }
        #endregion
    }
}