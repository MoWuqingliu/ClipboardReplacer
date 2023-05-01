using System.Windows;
using System.Text.RegularExpressions;


namespace ClipboardTool
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Read_Click(object sender, RoutedEventArgs e)
        {
            if (!Clipboard.ContainsText())
            {
                MessageBox.Show("No text in Clipboard");
                return;
            }
            var text = Clipboard.GetText();
            this.text.Text = text;
        }

        private void Write_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(text.Text);
            text.Text = "Write Sucessful";
        }

        private void Replace_Click(object sender, RoutedEventArgs e)
        {
            text.Text = Regex.Replace(text.Text, regex.Text, replace.Text);
        }
        private void Generate_Click(object sender, RoutedEventArgs e)
        {   
            if(text.Text.Length == 0)
            {
                MessageBox.Show("Emptpy String");
                return;
            }
            QRCodeWindow window = new(text.Text);
            window.ShowDialog();
        }
    }
}
