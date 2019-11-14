using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSample.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public class User
        {
            public int No { get; set; }
            public string Name { get; set; }

            public ReactiveProperty<bool> IsOpen { get; set; } = new ReactiveProperty<bool>();
            public ReactiveCommand EditCommand { get; set; } = new ReactiveCommand();

            public User(int no, string name)
            {
                this.No = no;
                this.Name = name;
                EditCommand.Subscribe(dataGrid => this.IsOpen.Value = true);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        public MainWindowViewModel()
        {
            Users.Add(new User(1, "Test User 01"));
            Users.Add(new User(2, "Test User 02"));
        }
    }
}
