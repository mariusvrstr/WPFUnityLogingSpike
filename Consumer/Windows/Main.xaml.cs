namespace Spike.Consumer.Windows
{
    using System.Windows;
    using Models;
    
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();

            var viewModel = new UserListViewModel();
            viewModel.GetLatestUsers();

            this.DataContext = viewModel;
        }
    }
}
