using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Shapes;



namespace ArteDraw 
{
  class variaveis : MainWindow 

  {

    public static string valor_var { get; set; }
    public static UIElement selectedElement = null;
    public static Shape atual = null;
    public static AdornerLayer adorners;
    public static string valor_mouse { get; set; }


    public string xy_mouse
    {
        get { return valor_mouse; }
        set { valor_mouse = value; }
    }



  }
}
