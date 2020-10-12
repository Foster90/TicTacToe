using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Private Members
        
        /// <summary>
        /// Holds the current results of the cell in the active game
        /// </summary>
        private MarkType[] mResults;
        
        /// <summary>
        /// True if it is player 1's turn (X ) or player 2's turn (O)
        /// </summary>    
        private bool mPlayer1Turn;
        
        /// <summary>
        /// True if Game ended
        /// /// </summary>
        private bool mGameEnded;


        #endregion



        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }


        #endregion

        /// <summary>
        /// Starts a new gamee clears all values
        /// </summary>

        private void NewGame()
        {
            //Create a new blank array of free cells
            mResults = new MarkType[9];

            for (int i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Free;
            }

            //Make sure Player 1 starts game;
            mPlayer1Turn = true;

            //Interate every button on the grid
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                //Change background, forground to defaul values.
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Green;
            });

            //make sure the game hasn't finshed
            mGameEnded = false;
            

        }


        /// <summary>
        /// Handles a button click event
        /// </summary>
        /// <param name="sender">The button that was clicked</param>
        /// <param name="e">The events of the click</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(mGameEnded)
            {
                NewGame();
                return;
            }

            var button = (Button)sender;



        }
    }



}
