using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomCommand.Commands
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new(
            "Exit",
            "Exit",
            typeof(CustomCommands),
            new InputGestureCollection() {new KeyGesture(Key.F5, ModifierKeys.Alt)}
        );

        //Other commands
    }
}
