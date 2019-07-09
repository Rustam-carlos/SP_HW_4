
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SP_HW_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyClass NewFile = new MyClass { filename = "MyFile.txt" };
        MyClass BackUpFile = new MyClass { filename = "BackUpFile.txt" };
        private DispatcherTimer timer = null;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10000);
            timer.Start();

            //TimerCallback callback = new TimerCallback(saveText);
            //Timer timer = new Timer(callback, null, 0, 2000);            
            //timer.Dispose();
        }

        private void timerTick(object sender, EventArgs e)
        {
            BackUpFile.textToSave = new TextRange(MyTextBox.Document.ContentStart, MyTextBox.Document.ContentEnd).Text;
            try
            {
                using (StreamWriter sw1 = new StreamWriter(BackUpFile.filename, true, System.Text.Encoding.Default))
                {
                    sw1.Write(BackUpFile.textToSave);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        public void Save()
        {
            MessageBox.Show("Запись файла");

            NewFile.textToSave = new TextRange(MyTextBox.Document.ContentStart, MyTextBox.Document.ContentEnd).Text;
            try
            {
                using (StreamWriter sw = new StreamWriter(NewFile.filename, true, System.Text.Encoding.Default))
                {
                    sw.Write(NewFile.textToSave);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Выход_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            //this.Close();
        }

        private void Сохранить_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void Сохранить_как_Click(object sender, RoutedEventArgs e)
        {
            // Configure save file dialog box
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
            }
        }

        private void Открыть_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
            }
        }

        private void Печать_Click(object sender, RoutedEventArgs e)
        {            
            System.Windows.Controls.PrintDialog dlg = new System.Windows.Controls.PrintDialog();
            dlg.PageRangeSelection = PageRangeSelection.AllPages;
            dlg.UserPageRangeEnabled = true;
            
            Nullable<bool> result = dlg.ShowDialog();

            
            if (result == true)
            {
                // Create the print dialog object and set options
                PrintDialog pDialog = new PrintDialog();
                pDialog.PageRangeSelection = PageRangeSelection.AllPages;
                pDialog.UserPageRangeEnabled = true;

                // Display the dialog. This returns true if the user presses the Print button.
                //Nullable<Boolean> print = pDialog.ShowDialog();
                //if (print == true)
                //{
                //    XpsDocument xpsDocument = new XpsDocument("C:\\FixedDocumentSequence.xps", FileAccess.ReadWrite);
                //    FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();
                //    pDialog.PrintDocument(fixedDocSeq.DocumentPaginator, "Test print job");
                //}
            }
        }

        private void Отменить_Click(object sender, RoutedEventArgs e)
        {
            MyTextBox.Undo();
        }

        private void Вырезать_Click(object sender, RoutedEventArgs e)
        {
            MyTextBox.Cut();
        }

        private void Копировать_Click(object sender, RoutedEventArgs e)
        {
            MyTextBox.Copy();
        }

        private void Вставить_Click(object sender, RoutedEventArgs e)
        {
            MyTextBox.Paste();
        }

        private void Удалить_Click(object sender, RoutedEventArgs e)
        {
           // MyTextBox.ClearValue.Content;
        }

        private void Выделить_все_Click(object sender, RoutedEventArgs e)
        {
            MyTextBox.SelectAll();
        }

        private void Найти_Click(object sender, RoutedEventArgs e)
        {
            //FrmFind _find = new NotepadSharp.FrmFind();
            //_find.Show();
        }

        private void Найти_далее_Click(object sender, RoutedEventArgs e)
        {
           // MyTextBox.FindResource
        }
    }
}
