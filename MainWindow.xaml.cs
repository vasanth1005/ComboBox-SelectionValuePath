using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ComboBox_SelectionValue
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private readonly ObservableCollection<ComboBoxItem> comboBoxItems = new() 
        {
            new ComboBoxItem("Heading 1 - Description 1", "Heading 1"),
            new ComboBoxItem("Heading 2 - Description 2", "Heading 2"),
            new ComboBoxItem("Heading 3 - Description 3", "Heading 3"),
            new ComboBoxItem("Heading 4 - Description 4", "Heading 4"),
            new ComboBoxItem("Heading 5 - Description 5", "Heading 5")
        };

        private void ComboBox_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine((sender as ComboBox).SelectedValue.ToString());
        }
    }

    public class ComboBoxItem : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        public ComboBoxItem(string listValue, string selectionValue)
        {
            ListValue = listValue;
            SelectionValue = selectionValue;
        }

        public string ListValue
        {
            get => _ListValue;
            set
            {
                if (_ListValue != value)
                {
                    _ListValue = value;
                    RaisePropertyChanged(nameof(ListValue));
                }
            }
        }
        private string _ListValue = "";

        public string SelectionValue
        {
            get => _SelectionValue;
            set
            {
                if (_SelectionValue != value)
                {
                    _SelectionValue = value;
                    RaisePropertyChanged(nameof(SelectionValue));
                }
            }
        }
        private string _SelectionValue = "";
    }
}
