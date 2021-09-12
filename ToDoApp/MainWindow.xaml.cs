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
using System.ComponentModel;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private readonly string PATH = $""
    private FileIOServices _fileIOServices;

    private BindingList<ToDoModel> _toDoDateList;   

    public MainWindow()
    {
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      _fileIOServices = new FileIOServices();
      _toDoDateList = new BindingList<ToDoModel>()
      {
        new ToDoModel(){Text = "Texxt"},
        new ToDoModel() { Text = "Terfgbh"}
      };
      dgToDoList.ItemsSource = _toDoDateList;
      _toDoDateList.ListChanged += _toDoDateList_ListChanged;
    }

    private void _toDoDateList_ListChanged(object sender, ListChangedEventArgs e)
    {
      if (e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted)
      {

      }
      
    }
  }
}
