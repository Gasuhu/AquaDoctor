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
using System.Data.SQLite;
using Aqua_Doctor.UserControls;

namespace Aqua_Doctor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow _obj;
        

        
        public MainWindow()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            _obj = this;
        }

        public void ButtonBack_Click(object sendern, RoutedEventArgs e)
        {
            if (MainGrid.Children.Contains(UserControl_Ajouter_Medecin.ajouterMed_Control))
            {
                ButtonGoBack.Visibility = Visibility.Hidden;
                MenuTextBlock.Text = "";
                MainGrid.Children.Clear();
                MainGrid.Children.Add(new UserControl_Medecin());
            }

            
        }


        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursor(index);

            ButtonGoBack.Visibility = Visibility.Hidden;
            MenuTextBlock.Text = "";


            switch (index)
            {
                case 3:
                    
                    MainGrid.Children.Clear();
                    MainGrid.Children.Add(new UserControl_Medecin());
                    break;
                default:
                    break;
            }
        }

        private void MoveCursor(int index)
        {
            TransitioningContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, 100 + (60 * index), 0, 0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                WindowMaximize.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowRestore;
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                WindowMaximize.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowMaximize;

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal || this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Minimized;
            }
            else if (this.WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
            } 
        }

        
    
    }
}
