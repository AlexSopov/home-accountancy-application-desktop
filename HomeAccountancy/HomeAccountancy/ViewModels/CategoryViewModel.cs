using HomeAccountancy.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace HomeAccountancy.ViewModels
{
    // TODO SelectedIncome, SelectedOutgo category property
    class CategoryViewModel : INotifyPropertyChanged
    {
        private Category _SelectedCategory;

        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Category> IncomeCategories { get; set; }
        public ObservableCollection<Category> OutgoCategories { get; set; }

        public int SelectedPage { get; set; }
        private RelayCommand _AddNewCommand;
        private RelayCommand _DeleteCommand;
        public RelayCommand AddNewCommand
        {
            get
            {
                return _AddNewCommand ??
                  (_AddNewCommand = new RelayCommand(commandAgrument =>
                  {
                      Category category = null;
                      if (SelectedPage == 0)
                      {
                          category = new OutgoCategory("Нова категорія витрат", "");
                          OutgoCategories.Add(category);
                      }
                      else
                      {
                          category = new IncomeCategory("Нова категорія доходів", "");
                          IncomeCategories.Add(category);
                      }

                      category?.Commit();
                      _SelectedCategory = category;
                      OnPropertyChanged("SelectedCategory");
                  }));
            }
        }
        public RelayCommand DeleteCommand
        {
            get
            {
                return _DeleteCommand ??
                  (_DeleteCommand = new RelayCommand(commandAgrument =>
                  {
                      if (MessageBox.Show("Ви дійсно бажаєте видалити категорію? Всі записи категорії буде видалено.",
                          "Підтвердження дії", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                      {
                          Category category = commandAgrument as Category;
                          if (category != null)
                          {
                              if (category is IncomeCategory)
                                  IncomeCategories.Remove(category);
                              else
                                  OutgoCategories.Remove(category);
                              category.Delete();
                          }
                      }
                  },
                 (commandAgrument) =>
                 {
                     if (SelectedPage == 0 && OutgoCategories.Count == 0)
                         return false;
                     else if (SelectedPage == 1 && IncomeCategories.Count == 0)
                         return false;

                     return SelectedCategory != null;
                 }));
            }
        }

        public Category SelectedCategory
        {
            get { return _SelectedCategory; }
            set
            {
                _SelectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        public CategoryViewModel()
        {
            Categories = Category.Entities;

            IncomeCategories = new ObservableCollection<Category>();
            foreach (Category category in Category.Entities)
                if (category is IncomeCategory)
                    IncomeCategories.Add(category);

            OutgoCategories = new ObservableCollection<Category>();
            foreach (Category category in Category.Entities)
                if (category is OutgoCategory)
                    OutgoCategories.Add(category);

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
