using System.Windows;
using System.Windows.Input;

namespace HFCS_Ch8_TwoDecksWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			if (Resources["rightDeck"] is Deck rightDeck)
				rightDeck.Clear();
			//Deck leftDeck = Resources["leftDeck"] as Deck;
		}

		private void MoveCard( bool leftToRight )
		{
			if ((Resources["rightDeck"] is Deck rightDeck) && (Resources["leftDeck"] is Deck leftDeck))
			{
				if (leftToRight)
				{
					if (leftDeckListBox.SelectedItem is Card card)
					{
						leftDeck.Remove(card);
						rightDeck.Add(card);
					}
				}
				else
				{
					if (rightDeckListBox.SelectedItem is Card card)
					{
						rightDeck.Remove(card);
						leftDeck.Add(card);
					}
				}
			}
		}
		private void shuffleLeftDeck_Click( object sender, RoutedEventArgs e )
		{
			if (Resources["leftDeck"] is Deck leftDeck)
			{
				leftDeck.Shuffle();
			}

		}

		private void clearRightDeck_Click( object sender, RoutedEventArgs e )
		{
			if (Resources["rightDeck"] is Deck rightDeck)
				rightDeck.Clear();
		}

		private void resetLeftDeck_Click( object sender, RoutedEventArgs e )
		{
			if (Resources["leftDeck"] is Deck leftDeck)
			{
				leftDeck.Reset();
			}
		}

		private void sortRightDeck_Click( object sender, RoutedEventArgs e )
		{
			if (Resources["rightDeck"] is Deck rightDeck)
			{
				rightDeck.Sort();
			}
		}

		private void leftDeckListBox_MouseDoubleClick( object sender, MouseButtonEventArgs e )
		{
			MoveCard(true);
		}

		private void leftDeckListBox_KeyDown( object sender, KeyEventArgs e )
		{
			if (e.Key == Key.Enter)
				MoveCard(true);
		}

		private void rightDeckListBox_KeyDown( object sender, KeyEventArgs e )
		{
			if (e.Key == Key.Enter)
				MoveCard(false);
		}

		private void rightDeckListBox_MouseDoubleClick( object sender, MouseButtonEventArgs e )
		{
			MoveCard(false);
		}
	}
}
