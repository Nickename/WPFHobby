using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFHobby.Models;

namespace WPFHobby.ViewModels
{
    public class HobbyItemViewModel : ViewModelBase
    {
        private readonly Hobby _model;

        public HobbyItemViewModel(Hobby model)
        {
            _model = model;
        }


        public string Title
        {
            get { return _model.Title; }
            set 
            { 
                _model.Title = value;
                RaisePropertyChanged();
            }
        }
        public string Description
        {
            get { return _model.Description; }
            set
            {
                _model.Description = value;
                RaisePropertyChanged();
            }
        }
    }
}
