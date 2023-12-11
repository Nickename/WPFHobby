using System;
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
        public DateTime Date
        {
            get { return _model.Date; }
            set
            {
                _model.Date = value;
                RaisePropertyChanged();
            }
        }
    }
}
