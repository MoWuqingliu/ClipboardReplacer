using QRCoder;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ClipboardTool
{
    /// <summary>
    /// QRCode.xaml 的交互逻辑
    /// </summary>
    public partial class QRCodeWindow : Window
    {
        public QRCodeWindow(String value)
        {
            InitializeComponent();

            using QRCodeGenerator qrGenerator = new();
            using QRCodeData qrCodeData = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
            using QRCode qrCode = new(qrCodeData);
            var qrCodeBitMap = qrCode.GetGraphic(20);

            MemoryStream stream = new();
            qrCodeBitMap.Save(stream, ImageFormat.Bmp);

            BitmapImage image = new();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();

            img.Source = image;
        }
        private void CloseKeyDown(object sender,KeyEventArgs e)
        {
            if (e.KeyStates == Keyboard.GetKeyStates(Key.Q)
                || e.KeyStates == Keyboard.GetKeyStates(Key.Space)
                || e.KeyStates == Keyboard.GetKeyStates(Key.Enter))
            {
                DialogResult = true;
            }

        }

    }


}
