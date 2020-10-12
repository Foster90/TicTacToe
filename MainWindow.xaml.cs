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
                button.Foreground = Brushes.Blue;
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

            //Cast the sender to a button
            var button = (Button)sender;

            //Find the buttons position in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            //Don't do anything if the cell already has a value in it
            if( mResults[index] != MarkType.Free)
            {
                return;
            }

            // Set the cell value based on which players turn it is

            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            // Set button test to the result
            button.Content = mPlayer1Turn ? "X" : "O";

            //Change noughts to green
            if (!mPlayer1Turn)
            {
                button.Foreground = Brushes.Red;
            }
            // Toggle the players turns
            mPlayer1Turn ^= true;


            //Check for a winner
            CheckForWinner();
                

        }

        /// <summary>
        /// Checks if there is a winner of a 3 line straigth
        /// </summary>
        private void CheckForWinner()
        {
            #region Horizontal Winners
            //Check for horixontal winners
            // Row 0
            //

            if (mResults[0] != MarkType.Free && (mResults[0] & mResults [1] & mResults[2]) == mResults[0])
            {
                mGameEnded = true;

                // Highlight winning cells in green

                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;

            }

            //Check for horixontal winners
            // Row 1
            //

            if (mResults[0] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[0])
            {
                mGameEnded = true;

                // Highlight winning cells in green

                Button0_1.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;

            }

            //Check for horixontal winners
            // Row 2
            //

            if (mResults[0] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[0])
            {
                mGameEnded = true;

                // Highlight winning cells in green

                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;

            }

            #endregion

            #region Vertial Winners
            //Check for vertial winners
            // Column 0
            //

            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                mGameEnded = true;

                // Highlight winning cells in green

                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;

            }

            //Check for vertial winners
            // Column 1
            //

            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                mGameEnded = true;

                // Highlight winning cells in green

                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;

            }

            //Check for vertial winners
            // Column 2
            //

            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                mGameEnded = true;

                // Highlight winning cells in green

                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;

            }

            #endregion

            #region Diagonal Win

            //Check for Diagonal winners
            // Top Left Botton Rigth
            //

            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                mGameEnded = true;

                // Highlight winning cells in green

                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;

            }

            //Check for Diagonal winners
            // Top Rigth Bottom Left
            //

            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                mGameEnded = true;

                // Highlight winning cells in green

                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.Green;

            }
         



            #endregion

            #region No Winners
            //Check for no winner
            if (!mResults.Any(result => result == MarkType.Free))
            {

                //Games End
                mGameEnded = true;

                // Turn all cells orange
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    
                    button.Background = Brushes.Orange;

                });

            }
            #endregion
        }
    }



}
