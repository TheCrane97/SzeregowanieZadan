using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using ZmodyfikowanyLiu;

namespace ZmodyfikowanyLiuGUI
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
            Dane.Wczytaj("dane1.txt");
            ManagerZadan.Acyklicznosc();
            if (ManagerZadan.status == true)
            {
                dataGrid.Items.Clear();
                dataGrid1.Items.Clear();
                opoznienie.Items.Clear();
                var dataGridWidth = dataGrid.Width;
                ManagerZadan.UstawienieZmodyfikowanychCzasowZakonczenia();
                ManagerZadan.UstawienieZadanNaMaszynie();

                var maxColumnNumber = ManagerZadan.maszyna.Last().czasZakonczenia;

                var width = dataGridWidth / maxColumnNumber;
                int licznik = 1;
                int k = 0;

                DataGridTextColumn op = new DataGridTextColumn();
                op.FontSize = 25;
                op.Header = "Opoznienie: " + ManagerZadan.WyliczenieOpoznienia();
                opoznienie.Columns.Add(op);

                if (ManagerZadan.maszyna.ElementAt(0).czasRozpoczecia != 0)
                {
                    for (int i = 0; i < ManagerZadan.maszyna.ElementAt(0).czasRozpoczecia; i++)
                    {
                        DataGridTextColumn column = new DataGridTextColumn();
                        column.FontSize = 25;
                        column.Header = k;
                        column.Width = width;
                        dataGrid1.Columns.Add(column);
                        k++;


                        DataGridTextColumn txtColumn = new DataGridTextColumn();
                        txtColumn.FontSize = 25;
                        txtColumn.Header = "X";
                        txtColumn.Width = width;
                        dataGrid.Columns.Add(txtColumn);

                    }

                }

                for (int i = 0; i < ManagerZadan.maszyna.Count(); i++)
                {
                    DataGridTextColumn column = new DataGridTextColumn();
                    column.FontSize = 25;
                    column.Header = k;
                    column.Width = width;
                    dataGrid1.Columns.Add(column);
                    k++;


                    if (i < ManagerZadan.maszyna.Count() - 1)
                    {


                        if (ManagerZadan.maszyna.ElementAt(i).numerZadania == ManagerZadan.maszyna.ElementAt(i + 1).numerZadania)
                            licznik++;
                        else
                        {
                            DataGridTextColumn textColumn = new DataGridTextColumn();
                            //switch (ManagerZadan.maszyna.ElementAt(i).numerZadania)
                            //{
                            //    case 1: textColumn.Foreground = new SolidColorBrush(Colors.Red); break;


                            //}

                            textColumn.FontSize = 25;

                            textColumn.Header = "Z" + ManagerZadan.maszyna.ElementAt(i).numerZadania;
                            textColumn.Width = licznik * width;
                            dataGrid.Columns.Add(textColumn);
                            licznik = 1;
                        }

                        if (ManagerZadan.maszyna.ElementAt(i).czasZakonczenia != ManagerZadan.maszyna.ElementAt(i + 1).czasRozpoczecia)
                        {
                            int roznica = ManagerZadan.maszyna.ElementAt(i + 1).czasRozpoczecia - ManagerZadan.maszyna.ElementAt(i).czasZakonczenia;

                            for (int j = 0; j < roznica; j++)
                            {
                                DataGridTextColumn txtColumn = new DataGridTextColumn();
                                txtColumn.FontSize = 25;
                                txtColumn.Header = "X";
                                txtColumn.Width = width;
                                dataGrid.Columns.Add(txtColumn);


                                DataGridTextColumn c = new DataGridTextColumn();
                                c.FontSize = 25;
                                c.Header = k;
                                c.Width = width;
                                dataGrid1.Columns.Add(c);
                                k++;



                            }

                        }

                    }
                    if (i == ManagerZadan.maszyna.Count() - 1)
                    {

                        DataGridTextColumn textColumn = new DataGridTextColumn();
                        textColumn.FontSize = 20;
                        textColumn.Header = "Z" + ManagerZadan.maszyna.ElementAt(i).numerZadania;
                        textColumn.Width = licznik * width;
                        dataGrid.Columns.Add(textColumn);
                        licznik = 1;
                    }



                }


            }
            else
            {
                MessageBox.Show("Graf jest cykliczny!");
            }

    
        }


    }
}
