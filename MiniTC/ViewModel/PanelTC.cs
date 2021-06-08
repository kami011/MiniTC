using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MiniTotalCommander.ViewModel
{
    using BaseClass;
    using System.Windows.Input;

    class PanelTC : ViewModel
    {
        string _currDrive;
        string _currDir;
        string _path;
        Model model = new Model();

        public string currDrive
        {
            get => _currDrive;
            set
            {
                _currDrive = value;
                onPropertyChange(nameof(currDrive));
            }
        }

        public string currDir
        {
            get => _currDir;
            set
            {
                _currDir = value;
                onPropertyChange(nameof(currFiles));
                onPropertyChange(nameof(currDir));
            }
        }

        public string selectedItem { get; set; }

        public string path
        {
            get => _path;
            set
            {
                _path = value;
                onPropertyChange(nameof(path));
            }
        }

        public ObservableCollection<string> currFiles
        {
            get => new ObservableCollection<string>(model.getFiles(currDir));         
        }

        public ObservableCollection<string> drives
        {
            get => new ObservableCollection<string>(model.getDrives());
        }

        private ICommand _click = null;
        public ICommand click
        {
            get
            {
                if (_click == null)
                {
                    _click = new RelayCommand(x => { currDir = model.setPath(currDir, selectedItem); }, x => true);
                }
                return _click;
            }
        }

    }
}
