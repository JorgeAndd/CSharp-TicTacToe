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

            var name = cell.Name;
            int index = name[name.Length - 1] - '0';

            var txt = cell.Children.OfType<TextBlock>().FirstOrDefault();
            txt.Text = game.getCurrentPlayer().ToString();
            var winner = game.markCell(index);
            
            if(winner != ' ') //Has winner
            {
                txtVencedor.Text = "O vencedor é o jogador " + winner;
                hasWinner = true;
            }
            else
            {
                txtPlayer.Text = game.getCurrentPlayer().ToString();
            }


        }
    }
}
