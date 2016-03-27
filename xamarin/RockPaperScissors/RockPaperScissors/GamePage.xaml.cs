using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RockPaperScissors
{
	public partial class GamePage : ContentPage
	{
		private readonly Random getrandom = new Random();
		private readonly object syncLock = new object();

		public GamePage ()
		{
			InitializeComponent ();
		}

		private void OnUserChoiceButtonClicked(object sender, EventArgs args)
		{
			HandleUserChoice(((Button)sender).Text);
		}

		private void HandleUserChoice(string userChoice) {
			//0 - rock, 1 - paper, 2 - scissors
			var computerChoice = GetRandomInt(0, 2);
				
			switch (userChoice) {
			case "ROCK":
				if (computerChoice == 0) {
					HandleUserChoice("ROCK");
				} else if (computerChoice == 1) {
					ShowResultsToUser(false);
					ComputerChoiceLabel.Text = "Computer: PAPER";
				} else {
					ShowResultsToUser(true);
					ComputerChoiceLabel.Text= "Computer: SCISSORS";
				}
				break;
			case "PAPER":
				if (computerChoice == 1) {
					HandleUserChoice("paper");
				} else if (computerChoice == 0) {
					ShowResultsToUser(true);
					ComputerChoiceLabel.Text = "Computer: ROCK";
				} else {
					ShowResultsToUser(false);
					ComputerChoiceLabel.Text = "Computer: SCISSORS";
				}

				break;
			case "SCISSORS":
				if (computerChoice == 2) {
					HandleUserChoice("scissors");
				} else if (computerChoice == 1) {
					ShowResultsToUser(true);
					ComputerChoiceLabel.Text = "Computer: PAPER";
				} else {
					ShowResultsToUser(false);
					ComputerChoiceLabel.Text = "Computer: ROCK";
				}
				break;
			}

			UserChoiceLabel.Text = "You: " + userChoice;
		}

		private int GetRandomInt(int min, int max)
		{
			lock(syncLock) { 
				return getrandom .Next(min, max);
			}
		}

		private void ShowResultsToUser(bool didUserWin) {
			ResultLabel.Text = didUserWin ? "YOU WON!" : "YOU LOST!";
		}
	}
}

