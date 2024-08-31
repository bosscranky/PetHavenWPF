using PetHaven.Domain;
using PetHavenWPF.DataLayer;
using System.Diagnostics.Eventing.Reader;
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

namespace PetHavenWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PetHaven.BusinessLayer.PetBusinessLayer BusinessLayer {  get; set; }    

        public MainWindow()
        {
            InitializeComponent();
            BusinessLayer = new PetHaven.BusinessLayer.PetBusinessLayer(new PetHavenDataLayer());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var pets = BusinessLayer.FindPetsByName(tbName.Text);

            DisplayPetResults(pets);
        }

        private void btnFindAll_Click(object sender, RoutedEventArgs e)
        {
            var pets = BusinessLayer.FindPets();
            DisplayPetResults(pets);
        }

        private void DisplayPetResults(List<BasePet> pets)
        {
            if (pets != null && pets.Count > 0)
            {
                foreach (var pet in pets)
                {
                    MessageBox.Show("found pet name " + pet.Name);
                }

            }
            else
            {
                MessageBox.Show("No matches found");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var add = new AddScreen(BusinessLayer);

            add.Show();
        }
    }
}