using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using WpfApplication1.Enums;
using WpfApplication1.ViewModels;
using WpfApplication1.Views;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new Window();
            var view = new MainView();
            var viewModel = new MainViewModel();

            viewModel.FamilyVMs = new ObservableCollection<FamilyViewModel>
            {
                new FamilyViewModel()
                {
                    Surname = "Ивановы",
                    PersonVMs = new ObservableCollection<PersonViewModel>
                    {
                        new PersonViewModel()
                        {
                            Name = "Пётр",
                            LastName = "Иванов",
                            Gender = Gender.Male,
                        },
                        new PersonViewModel()
                        {
                            Name = "Ирина",
                            LastName = "Иванова",
                            Gender = Gender.Female,
                        },
                        new PersonViewModel()
                        {
                            Name = "Роман",
                            LastName = "Иванов",
                            Gender = Gender.Male,
                        },
                    },
                },
                new FamilyViewModel()
                {
                    Surname = "Петровы",
                    PersonVMs = new ObservableCollection<PersonViewModel>
                    {
                        new PersonViewModel()
                        {
                            Name = "Семён",
                            LastName = "Петров",
                            Gender = Gender.Male,
                        },
                        new PersonViewModel()
                        {
                            Name = "Оксана",
                            LastName = "Петрова",
                            Gender = Gender.Female,
                        },
                    },
                },
                new FamilyViewModel()
                {
                    Surname = "Силиконовы",
                    PersonVMs = new ObservableCollection<PersonViewModel>
                    {
                        new PersonViewModel()
                        {
                            Name = "Аркадий",
                            LastName = "Силиконов",
                            Gender = Gender.Male,
                        },
                        new PersonViewModel()
                        {
                            Name = "Вероника",
                            LastName = "Андреева",
                            Gender = Gender.Female,
                        },
                        new PersonViewModel()
                        {
                            Name = "Земфира",
                            LastName = "Силиконова",
                            Gender = Gender.Female,
                        },
                        new PersonViewModel()
                        {
                            Name = "Александр",
                            LastName = "Силиконов",
                            Gender = Gender.Male,
                        },
                        new PersonViewModel()
                        {
                            Name = "Кирилл",
                            LastName = "Силиконов",
                            Gender = Gender.Male,
                        },
                        new PersonViewModel()
                        {
                            Name = "Лорелея",
                            LastName = "Силиконова",
                            Gender = Gender.Female,
                        },
                    },
                },
            };

            view.DataContext = viewModel;
            window.Content = view;
            window.Show();
        }
    }
}
