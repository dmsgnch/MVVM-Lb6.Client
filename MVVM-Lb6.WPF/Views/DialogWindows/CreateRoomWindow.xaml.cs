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
using MVVM_Lb6.ViewModels;

namespace MVVM_Lb6.Views.DialogWindows
{
    public partial class CreateRoomWindow : Window
    {
		public CreateRoomWindow(RoomsListingViewModel roomsListingViewModel, string operation)
        {
            //Add MainWindowsViewModel object into constructor in order to do not create new and use already existed instead
            InitializeComponent();

            Title = operation;

            DataContext = roomsListingViewModel;
		}

		/// <summary>Set success result for dialog window</summary>
		private void Accept_Click(object sender, RoutedEventArgs e) // Of course, better way is to create a new command, but this way is easier
        {
            this.DialogResult = true;
        }

		private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!IsNumericInput(e.Text))
			{
				e.Handled = true; // Предотвращает ввод неправильных символов
			}
		}

		private bool IsNumericInput(string text)
		{
			return int.TryParse(text, out _); // Возвращает true, если текст является числом
		}
	}
}
