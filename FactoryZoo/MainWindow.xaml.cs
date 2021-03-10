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

namespace FactoryZoo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AnimalFactory animalFactory = new();
        List<string> animalNames = new List<string>();
        List<Animal> allAnimals = new List<Animal>();

        public MainWindow() => InitializeComponent();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAnimals();
        }

        private void LoadAnimals()
        {
            foreach (var name in animalFactory.AnimalNames)
            {
                animalNames.Add(name);
            }
            comboBoxSpecies.ItemsSource = animalNames;
        }

        private void buttonBuy_Click(object sender, RoutedEventArgs e)
        {
            string name = comboBoxSpecies.SelectedItem.ToString();
            int amount = Int32.Parse(textBoxAmountSpecies.Text);
            try
            {
                List<Animal> animals = animalFactory.Create(name, amount);
                animals.ForEach(x => allAnimals.Add(x));                
                lstViewAnimalsStock.Items.Add($"{animals.Count()} x {animals[0]}");

                lblGreenFood.Content = allAnimals.Sum(x => x.GreenFoodAmount);
                lblMeatFood.Content = allAnimals.Sum(x => x.MeatFoodAmount);
                lblTotalAmount.Content = allAnimals.Sum(x => x.Price);


            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
        }
    }
}
