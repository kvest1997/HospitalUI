using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalUIWpfTest
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
        //внести
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (HospitalDbContext db = new HospitalDbContext())
            {
                Analysis analys1 = new Analysis { AnalysesName = $"{txtbox.Text}" };
                db.Analyses.Add(analys1);
                db.SaveChanges();
            }
        }
        //удалить
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using(HospitalDbContext db = new HospitalDbContext())
            {
                Analysis analysis = db.Analyses.FirstOrDefault();

                if (analysis != null)
                {
                    db.Analyses.Remove(analysis);
                    db.SaveChanges();
                }
            }
        }
        //редактировать
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (HospitalDbContext db = new HospitalDbContext())
            {
                Analysis analysis = db.Analyses.FirstOrDefault();

                if (analysis != null)
                {
                    analysis.AnalysesName = txtbox.Text;
                    db.Analyses.Update(analysis);
                    db.SaveChanges();
                }
            }
        }
        //получить
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            using (HospitalDbContext db = new HospitalDbContext())
            {
                Analysis analysis = db.Analyses.FirstOrDefault();
                if (analysis != null)
                {
                    MessageBox.Show($"{analysis.AnalysesName} {analysis.AnalysesId}");
                }
            }
        }
    }
}