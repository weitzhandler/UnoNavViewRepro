using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UnoNavViewRepro
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();
    }
  }

  public class NavigationViewModel : INotifyPropertyChanged
  {
    public IList<NavigationItemViewModel> Items { get; } =
      new[]
      {
        new NavigationItemViewModel("Home", Symbol.Home.ToString()),
        new NavigationItemViewModel("Settings", Symbol.Setting.ToString())
      };

    NavigationItemViewModel _SelectedItem;
    public NavigationItemViewModel SelectedItem
    {
      get => _SelectedItem;
      set
      {
        _SelectedItem = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }

  public class NavigationItemViewModel
  {
    public NavigationItemViewModel(string title, string symbol)
    {
      //we don't want to use UI code in our VM
      Debug.Assert(Enum.TryParse<Symbol>(symbol, out var _));
      Title = title;
      Symbol = symbol;
    }

    public string Title { get; }
    public string Symbol { get; }
  }
}
