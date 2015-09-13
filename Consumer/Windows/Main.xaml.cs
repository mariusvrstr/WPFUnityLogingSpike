namespace Spike.Consumer.Windows
{
    using System.Windows;
    using Models;
    
    public partial class Main : Window
    {
        protected UserListViewModel Model
        {
            get { return (UserListViewModel)Resources["ViewModel"]; }
        } 
        
        public Main()
        {
            InitializeComponent();
        }
    }
}
