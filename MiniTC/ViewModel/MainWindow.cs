using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniTotalCommander.ViewModel
{
    using BaseClass;
    using System.Windows.Input;

    class MainWindow : ViewModel
    {
        private PanelTC _left;
        private PanelTC _right;

        public MainWindow()
        {
            left = new PanelTC();
            right = new PanelTC();
        }

        public PanelTC left
        {
            get => _left;
            set 
            { 
                _left = value; 
                onPropertyChange(nameof(left)); 
            }
        }

        public PanelTC right
        {
            get => _right;
            set 
            { 
                _right = value; 
                onPropertyChange(nameof(right)); 
            }
        }

        Model model = new Model();


        private ICommand _Copy = null;
        public ICommand Copy
        {
            get
            {
                if (_Copy == null)
                {
                    _Copy = new RelayCommand(x =>
                    {
                        if (right.currDir != null & left.selectedItem != null)
                        {
                            string source = left.currDir + @"\" + left.selectedItem;
                            string destination = right.currDir + @"\" + left.selectedItem;
                            model.copy(source, destination);
                            onPropertyChange(nameof(right));
                        }

                        if (left.currDir != null & right.selectedItem != null)
                        {
                            string source = right.currDir + @"\" + right.selectedItem;
                            string destination = left.currDir + @"\" + right.selectedItem;
                            model.copy(source, destination);
                            onPropertyChange(nameof(left));
                        }

                    }, x => true);
                }
                return _Copy; 
            }
        }

    }
}
