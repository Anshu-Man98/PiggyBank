using System;
using PiggyBank.Model;
using System.Collections.Generic;
using Xamarin.Forms;
using System.ComponentModel;

namespace PiggyBank.ViewModel
{
    public class AddExpenceIncomeLogicVM
    {
        private readonly IUserDatabase _userDatabase;
        public AddExpenceIncomeLogicVM()
        {
            this._userDatabase = DependencyService.Get<IUserDatabase>();
            getCategories();
        }

        public List<ExpenceCategory> categories = null;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public List<ExpenceCategory> Categories
        {
            set { categories = value; OnPropertyChanged(nameof(Categories)); }
            get { return categories; }
        }

        private void getCategories()
        {
            categories = _userDatabase.Expencecategories();
        }
    }
}

