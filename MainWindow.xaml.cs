using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
                button.Content = string.Empty;
            });

        }
    }



}
