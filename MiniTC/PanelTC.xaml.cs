using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiniTotalCommander
{
    /// <summary>
    /// Logika interakcji dla klasy PanelTC.xaml
    /// </summary>
    /// 

    public partial class PanelTC : UserControl
    {
        public static readonly DependencyProperty currPathProperty =
            DependencyProperty.Register(nameof(currentPath), typeof(string), typeof(PanelTC),
                new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty currFileProperty =
            DependencyProperty.Register(nameof(currentItem), typeof(string), typeof(PanelTC),
                new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty filesProperty =
            DependencyProperty.Register(nameof(theFiles), typeof(ObservableCollection<string>), typeof(PanelTC),
                new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty drivesProperty =
            DependencyProperty.Register(nameof(theDrives), typeof(ObservableCollection<string>), typeof(PanelTC),
                new FrameworkPropertyMetadata(null));


        public string currentPath
        {
            get => (string)GetValue(currPathProperty);
            set
            {
                SetValue(currPathProperty, value);
            }
        }

        public string currentItem
        {
            get => (string)GetValue(currFileProperty);
            set
            {
                SetValue(currFileProperty, value);
            }
        }

        public ObservableCollection<string> theFiles
        {
            get => (ObservableCollection<string>)GetValue(filesProperty);
            set 
            {
                SetValue(filesProperty, value);
            }
        }

        public ObservableCollection<string> theDrives
        {
            get => (ObservableCollection<string>)GetValue(drivesProperty);
            set
            {
                SetValue(drivesProperty, value);
            }
        }

        private void driveChanged(object sender, SelectionChangedEventArgs e)
        {
            currentPath = e.AddedItems[0].ToString();
        }

        public PanelTC()
        {
            InitializeComponent();
        }
    }
}
