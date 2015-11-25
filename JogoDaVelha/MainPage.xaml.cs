using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace JogoDaVelha
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private bool hasWinner = false;
        Game game = new Game();

        public MainPage()
        {
            this.InitializeComponent();

            txtPlayer.Text = "X";
        }

        private void TextBlock_PointerPressed(object sender, PointerRoutedEventArgs e)
        {

        }

        private void Cell_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (hasWinner)
                return;

            var cell = (Grid)sender;
			var txt = cell.Children.OfType<TextBlock>().FirstOrDefault();

			//Check if cell is already marked
			if (txt.Text != "")
				return;

			var name = cell.Name;
            int index = name[name.Length - 1] - '0';

            
            txt.Text = game.GetCurrentPlayer().ToString();
            var winner = game.MarkCell(index);

			switch(winner)
			{
				// No winner yet
				case 0:
					txtPlayer.Text = game.GetCurrentPlayer().ToString();
					return;
				case 1:
					txtVencedor.Text = "O vencedor é o jogador X";
					hasWinner = true;

					btnReplay.Content = "Jogar Novamente";
					return;
				case 2:
					txtVencedor.Text = "O vencedor é o jogador O";
					hasWinner = true;

					btnReplay.Content = "Jogar Novamente";
					return;
				case 3:
					txtVencedor.Text = "Empate!";
					hasWinner = true;

					btnReplay.Content = "Jogar Novamente";
					return;
			}

        }

		private void btnReplay_Click(object sender, RoutedEventArgs e)
		{
			//Clear each cell on the grid
			foreach(Grid cell in Board.Children.OfType<Grid>())
			{
				var txt = cell.Children.OfType<TextBlock>().FirstOrDefault();

				txt.Text = "";
			}

			txtVencedor.Text = "";
			hasWinner = false;
			game.Restart();
			btnReplay.Content = "Reiniciar Jogo";
		}
	}
}
