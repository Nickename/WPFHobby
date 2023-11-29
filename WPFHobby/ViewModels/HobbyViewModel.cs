using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
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
			set { _hobbies = value;
				RaisePropertyChanged();
			}
		}

		private HobbyItemViewModel selectedHobby;

		public HobbyItemViewModel SelectedHobby
		{
			get { return selectedHobby; }
			set { selectedHobby = value;
				RaisePropertyChanged();
				DeleteCommand.RaiseCanExecuteChanged();
			}
		}

		public DelegateCommand AddCommand { get; }
		public DelegateCommand DeleteCommand { get; }

        public HobbyViewModel()
        {
            _hobbies.Add(new HobbyItemViewModel(new Hobby {Title = "Prata med trädgårn", Description="Lär dig prata med din trägård så att du kan förstå den bättre"}));
            _hobbies.Add(new HobbyItemViewModel(new Hobby { Title = "Dansa utan vargar", Description = "Så dansar du utan dina vargar" }));
            _hobbies.Add(new HobbyItemViewModel(new Hobby { Title = "Horisontell Tapetsering", Description = "Din nya favorithobby kräver inga förkunskaper" }));

			AddCommand = new DelegateCommand(AddHobby);
			DeleteCommand = new DelegateCommand(DeleteHobby, CanDelete);
        }

		public async Task LoadAsync()
		{
			if(_hobbies.Any()) return;
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
			if(SelectedHobby != null)
			{
				Hobbies.Remove(SelectedHobby);
				SelectedHobby = null;
			}
		}
    }
}
