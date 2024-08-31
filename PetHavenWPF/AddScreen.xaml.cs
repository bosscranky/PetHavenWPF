using PetHaven.Domain;
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
using System.Windows.Shapes;

namespace PetHavenWPF
{
    /// <summary>
    /// Interaction logic for AddScreen.xaml
    /// </summary>
    public partial class AddScreen : Window
    {
        private PetHaven.BusinessLayer.PetBusinessLayer BusinessLayer { get; }

        public AddScreen(PetHaven.BusinessLayer.PetBusinessLayer bl)
        {
            InitializeComponent();
            this.BusinessLayer = bl;
        }

        private void btnAddSnake_Click(object sender, RoutedEventArgs e)
        {
            var newSnake = new Snake() { Name = tbName.Text, Neutered = cbNeutered.IsChecked.HasValue ? cbNeutered.IsChecked.Value : false };

            var saved = BusinessLayer.SavePet(newSnake);

            if (saved != null)
            {
                MessageBox.Show("saved new snake named " + saved.Name + " with Id " + saved.Id);
            }
            else
            {
                MessageBox.Show("could not save new snake");
            }
        }

        private void btnCloseAndCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
