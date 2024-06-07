using System.Windows;

namespace ReservationSystem.View.ManagerView
{
    public partial class RejectReason : Window
    {
        public string Reason { get; private set; }
        public RejectReason()
        {
            InitializeComponent();
        }
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Reason = ReasonTextBox.Text;
            this.DialogResult = true;
            this.Close();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}