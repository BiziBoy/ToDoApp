using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
  class ToDoModel : INotifyPropertyChanged
  {
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public DateTime DeadLine { get; set; } = DateTime.Today;
    private bool _isDone;
    private string _text;

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

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChange(string propertyName = "")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
