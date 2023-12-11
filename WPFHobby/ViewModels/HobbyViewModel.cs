using System;
using System.Collections.ObjectModel;
using WPFHobby.Command;
using WPFHobby.Models;

namespace WPFHobby.ViewModels
{
    public class HobbyViewModel : ViewModelBase
    {
        private ObservableCollection<HobbyItemViewModel> _hobbies = new ObservableCollection<HobbyItemViewModel>();

        public ObservableCollection<HobbyItemViewModel> Hobbies
        {
            get { return _hobbies; }
            set
            {
                _hobbies = value;
                RaisePropertyChanged();
            }
        }

        private HobbyItemViewModel selectedHobby;

        public HobbyItemViewModel SelectedHobby
        {
            get { return selectedHobby; }
            set
            {
                selectedHobby = value;
                RaisePropertyChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand AddCommand { get; }
        public DelegateCommand DeleteCommand { get; }

        public HobbyViewModel()
        {
            _hobbies.Add(new HobbyItemViewModel(new Hobby { Title = "Prata med trädgårn", Date = DateTime.Today }));
            _hobbies.Add(new HobbyItemViewModel(new Hobby { Title = "Sätta ner foten", Date = DateTime.Today }));
            _hobbies.Add(new HobbyItemViewModel(new Hobby { Title = "Horisontell Tapetsering", Date = DateTime.Today }));

            AddCommand = new DelegateCommand(AddHobby);
            DeleteCommand = new DelegateCommand(DeleteHobby, CanDelete);
        }

        private bool CanDelete(object? parameter) => SelectedHobby != null;

        private void AddHobby(object? parameter)
        {
            Hobby hobby = new Hobby { Title = "new" };
            var hobbyVM = new HobbyItemViewModel(hobby);
            Hobbies.Add(hobbyVM);
            selectedHobby = hobbyVM;
        }
        private void DeleteHobby(object? parameter)
        {
            if (SelectedHobby != null)
            {
                Hobbies.Remove(SelectedHobby);
                SelectedHobby = null;
            }
        }
    }
}
