using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using ZmodyfikowanyJohnson;
namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dane.Wczytaj("dane.txt");

            dataGrid.Items.Clear();
            dataGridM2.Items.Clear();
            dataGridM3.Items.Clear();
            dataGrid1.Items.Clear();

            var dataGridWidth = dataGrid.Width;
            ManagerZadan.UstawianieListZmodyfikowanychCzasow();
            if(ManagerZadan.SprawdzenieDanych()==true)
            { 
                ManagerZadan.UstawienieNaMaszynach();



                int os = 0;

                foreach (Zadanie zad in ManagerZadan.M1)
                {
                    if (zad.czasZakonczenia > os)
                        os = zad.czasZakonczenia;

                }

                foreach (Zadanie zad in ManagerZadan.M2)
                {
                    if (zad.czasZakonczenia > os)
                        os = zad.czasZakonczenia;

                }

                foreach (Zadanie zad in ManagerZadan.M3)
                {
                    if (zad.czasZakonczenia > os)
                        os = zad.czasZakonczenia;

                }
                var maxColumnNumber = os;

                var width = dataGridWidth / maxColumnNumber;
                int licznik = 1;
                int k = 0;
                int roznica;

                if (ManagerZadan.M1.ElementAt(0).czasRozpoczecia != 0)
                {

                        DataGridTextColumn txtColumn = new DataGridTextColumn();
                        txtColumn.FontSize = 25;
                        txtColumn.Header = "X";
                        txtColumn.Width = ManagerZadan.M1.ElementAt(0).czasRozpoczecia*width;
                        dataGrid.Columns.Add(txtColumn);

                }

                for (int i = 0; i < ManagerZadan.M1.Count(); i++)
                {


                    if (i < ManagerZadan.M1.Count() - 1)
                    {

                        DataGridTextColumn textColumn = new DataGridTextColumn();
                        textColumn.FontSize = 25;
                        textColumn.Header = "Z" + ManagerZadan.M1.ElementAt(i).numerZadania;
                        textColumn.Width = ManagerZadan.M1.ElementAt(i).czasM1 * width;
                        dataGrid.Columns.Add(textColumn);

                        if (ManagerZadan.M1.ElementAt(i).czasZakonczenia != ManagerZadan.M1.ElementAt(i + 1).czasRozpoczecia)
                        {
                             roznica = ManagerZadan.M1.ElementAt(i + 1).czasRozpoczecia - ManagerZadan.M1.ElementAt(i).czasZakonczenia;

                                DataGridTextColumn txtColumn = new DataGridTextColumn();
                                txtColumn.FontSize = 25;
                                txtColumn.Header = "X";
                                txtColumn.Width = roznica*width;
                                dataGrid.Columns.Add(txtColumn);

                        

                        }

                    }
                    if (i == ManagerZadan.M1.Count() - 1)
                    {

                        DataGridTextColumn textColumn = new DataGridTextColumn();
                        textColumn.FontSize = 20;
                        textColumn.Header = "Z" + ManagerZadan.M1.ElementAt(i).numerZadania;
                        textColumn.Width = ManagerZadan.M1.ElementAt(i).czasM1 * width;
                        dataGrid.Columns.Add(textColumn);
                        licznik = 1;
                    }



                }

                if (ManagerZadan.M2.ElementAt(0).czasRozpoczecia != 0)
                {

                        DataGridTextColumn txtColumn = new DataGridTextColumn();
                        txtColumn.FontSize = 25;
                        txtColumn.Header = "X";
                        txtColumn.Width = ManagerZadan.M2.ElementAt(0).czasRozpoczecia* width;
                        dataGridM2.Columns.Add(txtColumn);

                }

                for (int i = 0; i < ManagerZadan.M2.Count(); i++)
                {


                    if (i < ManagerZadan.M2.Count() - 1)
                    {

                        DataGridTextColumn textColumn = new DataGridTextColumn();
                        textColumn.FontSize = 25;
                        textColumn.Header = "Z" + ManagerZadan.M2.ElementAt(i).numerZadania;
                        textColumn.Width = ManagerZadan.M2.ElementAt(i).czasM2 * width;
                        dataGridM2.Columns.Add(textColumn);

                        if (ManagerZadan.M2.ElementAt(i).czasZakonczenia != ManagerZadan.M2.ElementAt(i + 1).czasRozpoczecia)
                        {
                            roznica = ManagerZadan.M2.ElementAt(i + 1).czasRozpoczecia - ManagerZadan.M2.ElementAt(i).czasZakonczenia;

                            DataGridTextColumn txtColumn = new DataGridTextColumn();
                            txtColumn.FontSize = 25;
                            txtColumn.Header = "X";
                            txtColumn.Width = roznica * width;
                            dataGridM2.Columns.Add(txtColumn);



                        }

                    }
                    if (i == ManagerZadan.M2.Count() - 1)
                    {

                        DataGridTextColumn textColumn = new DataGridTextColumn();
                        textColumn.FontSize = 20;
                        textColumn.Header = "Z" + ManagerZadan.M2.ElementAt(i).numerZadania;
                        textColumn.Width = ManagerZadan.M2.ElementAt(i).czasM2 * width;
                        dataGridM2.Columns.Add(textColumn);
                        licznik = 1;
                    }



                }


                if (ManagerZadan.M3.ElementAt(0).czasRozpoczecia != 0)
                {

                    DataGridTextColumn txtColumn = new DataGridTextColumn();
                    txtColumn.FontSize = 25;
                    txtColumn.Header = "X";
                    txtColumn.Width = ManagerZadan.M3.ElementAt(0).czasRozpoczecia * width;
                    dataGridM3.Columns.Add(txtColumn);

                }

                for (int i = 0; i < ManagerZadan.M3.Count(); i++)
                {


                    if (i < ManagerZadan.M3.Count() - 1)
                    {

                        DataGridTextColumn textColumn = new DataGridTextColumn();
                        textColumn.FontSize = 25;
                        textColumn.Header = "Z" + ManagerZadan.M3.ElementAt(i).numerZadania;
                        textColumn.Width = ManagerZadan.M3.ElementAt(i).czasM3 * width;
                        dataGridM3.Columns.Add(textColumn);

                        if (ManagerZadan.M3.ElementAt(i).czasZakonczenia != ManagerZadan.M3.ElementAt(i + 1).czasRozpoczecia)
                        {
                            roznica = ManagerZadan.M3.ElementAt(i + 1).czasRozpoczecia - ManagerZadan.M3.ElementAt(i).czasZakonczenia;

                            DataGridTextColumn txtColumn = new DataGridTextColumn();
                            txtColumn.FontSize = 25;
                            txtColumn.Header = "X";
                            txtColumn.Width = roznica * width;
                            dataGridM3.Columns.Add(txtColumn);



                        }

                    }
                    if (i == ManagerZadan.M3.Count() - 1)
                    {

                        DataGridTextColumn textColumn = new DataGridTextColumn();
                        textColumn.FontSize = 20;
                        textColumn.Header = "Z" + ManagerZadan.M3.ElementAt(i).numerZadania;
                        textColumn.Width = ManagerZadan.M3.ElementAt(i).czasM3 * width;
                        dataGridM3.Columns.Add(textColumn);
                        licznik = 1;
                    }



                }


                for (int i = 0; i < os; i++)
                {

                    DataGridTextColumn column = new DataGridTextColumn();
                    column.FontSize = 25;
                    column.Header = i;
                    column.Width = width;
                    dataGrid1.Columns.Add(column);
                
                }
            }
            else
            {
                MessageBox.Show("Maszyna M2 nie jest zdominowana ani przez M1, ani przez M3");
            }

        }

        


    }
}
