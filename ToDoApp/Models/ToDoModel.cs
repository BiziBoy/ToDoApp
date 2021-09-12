using System;
using System.ComponentModel;
using System.Windows;

namespace ToDoApp.Models
{
  class ToDoModel : INotifyPropertyChanged
  {
    public DateTime CreationDate { get; set; } = DateTime.Now;
    private string _deadLine;
    private bool _isDone;
    private string _text;

    public void Error()
    {
      MessageBox.Show("error");
    }

    public bool ChekDeadLine(string date)
    {
      if (date != null)
      {
        if (date?.Length < 1 || date?.Length > 8)
        {
          MessageBox.Show("Повторите ввод.");
          return false;
        }
        else
          return true;
      }
      else
      {
        MessageBox.Show("Повторите ввод.");
        return false;
      }
    }

    public bool IsDone
    {
      get { return _isDone; }
      set
      {
        if (_isDone != value)
        {
          _isDone = value;
        }
        OnPropertyChange("IsDone");
      }
    }
   
    public string Text
    {
      get { return _text; }
      set 
      {
        if (_text == value)
        {
          return;
        }
        _text = value;
        OnPropertyChange("Text");
      }
    }

    public string DeadLine
    {
      get { return _deadLine; }
      set
      {
        //if (_deadLine == value)
        //{
        //  return;
        //}
        //_deadLine = value;
        //OnPropertyChange("_deadLine");
        MessageBox.Show(value);
        if (ChekDeadLine(value))
        {
          if (_deadLine == value)
          {
            return;
          }
          _deadLine = value;
          OnPropertyChange("_deadLine");
        }
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChange(string propertyName = "")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
