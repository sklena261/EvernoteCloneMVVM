using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
		private User _user;

		public User User
		{
			get { return _user; }
			set { _user = value; }
		}

		public RegisterCommand RegisterCommand { get; set; }
		public LoginCommand LoginCommand { get; set; }
		public LoginViewModel()
		{
			RegisterCommand = new RegisterCommand(this);
			LoginCommand = new LoginCommand(this);
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
