using System;
using System.Windows;
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
    private readonly string PATH = $"{Environment.CurrentDirectory}\\toDoDataList.json";
    private FileIOServices _fileIOServices;

    private BindingList<ToDoModel> _toDoDateList;   

    public MainWindow()
    {
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      _fileIOServices = new FileIOServices(PATH);
      try
      {
        _toDoDateList = _fileIOServices.LoadData();
      }
      catch (Exception ex) 
      {
        MessageBox.Show(ex.Message);
        Close();
      }
      
      dgToDoList.ItemsSource = _toDoDateList;
      _toDoDateList.ListChanged += _toDoDateList_ListChanged;
    }

    private void _toDoDateList_ListChanged(object sender, ListChangedEventArgs e)
    {
      if (e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted)
      {
        try
        {
          _fileIOServices.SaveData(sender);
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message);
          Close();
        }
      }
      
    }
  }
}
