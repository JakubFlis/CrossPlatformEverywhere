﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RockPaperScissors
{
	public partial class GamePage : ContentPage
	{
		private enum GameChoice {
			Rock = 0,
			Paper = 1,
			Scissors = 2
		}
		private readonly Random getrandom = new Random();
		private readonly object syncLock = new object();

		public GamePage ()
		{
			InitializeComponent ();
		}

		private void OnUserChoiceButtonClicked(object sender, EventArgs args)
		{
			var source = ((Image)sender).Source as FileImageSource;
			HandleUserChoice(GetUserChoiceFromImageName(source.File));
		}

		private void HandleUserChoice(GameChoice userChoice) {
			var computerChoice = GetRandomInt(0, 2);
				
			switch (userChoice) {
				case GameChoice.Rock:
					if (computerChoice == (int)GameChoice.Rock) {
						HandleUserChoice(GameChoice.Rock);
					} else if (computerChoice == (int)GameChoice.Paper) {
						ShowResultsToUser(false);
						ComputerChoiceLabel.Text = "PAPER";
						SetOpponentImageSource (GameChoice.Paper);
					} else {
						ShowResultsToUser(true);
						ComputerChoiceLabel.Text= "SCISSORS";
						SetOpponentImageSource (GameChoice.Scissors);
					}
					break;
				case GameChoice.Paper:
					if (computerChoice == (int)GameChoice.Paper) {
						HandleUserChoice(GameChoice.Paper);
					} else if (computerChoice == (int)GameChoice.Rock) {
						ShowResultsToUser(true);
						ComputerChoiceLabel.Text = "ROCK";
						SetOpponentImageSource (GameChoice.Rock);
					} else {
						ShowResultsToUser(false);
						ComputerChoiceLabel.Text = "SCISSORS";
						SetOpponentImageSource (GameChoice.Scissors);
					}

					break;
				case GameChoice.Scissors:
					if (computerChoice == (int)GameChoice.Scissors) {
						HandleUserChoice(GameChoice.Scissors);
					} else if (computerChoice == (int)GameChoice.Paper) {
						ShowResultsToUser(true);
						ComputerChoiceLabel.Text = "PAPER";
						SetOpponentImageSource (GameChoice.Paper);
					} else {
						ShowResultsToUser(false);
						ComputerChoiceLabel.Text = "ROCK";
						SetOpponentImageSource (GameChoice.Rock);
					}
					break;
			}

			UserChoiceLabel.Text = GetUserChoiceStringFromEnum(userChoice);
			SetUserImageSource(userChoice);
		}

		private int GetRandomInt(int min, int max)
		{
			lock(syncLock) { 
				return getrandom .Next(min, max);
			}
		}

		private void ShowResultsToUser(bool didUserWin) {
			ResultLabel.Text = didUserWin ? "YOU WON!" : "YOU LOST!";
			ResultLabel.TextColor = didUserWin ? Color.Green : Color.Red;
		}

		private GameChoice GetUserChoiceFromImageName(string imageName) {
			switch (imageName) {
				case "rock.png":
					return GameChoice.Rock;
				case "scissors.png":
					return GameChoice.Scissors;
				case "paper.png":
					return GameChoice.Paper;
			}

			return GameChoice.Paper;
		}

		private string GetUserChoiceStringFromEnum(GameChoice userChoice) {
			switch (userChoice) {
				case GameChoice.Paper:
					return "PAPER";
				case GameChoice.Rock:
					return "ROCK";
				case GameChoice.Scissors:
					return "SCISSORS";
			}

			return "ROCK";
		}

		private void SetOpponentImageSource(GameChoice gameChoice) {
			switch (gameChoice) {
				case GameChoice.Rock:
					ComputerChoiceImage.Source = ImageSource.FromFile ("rock_op.png");
					break;
				case GameChoice.Paper:
					ComputerChoiceImage.Source = ImageSource.FromFile ("paper_op.png");
					break;
				case GameChoice.Scissors:
					ComputerChoiceImage.Source = ImageSource.FromFile ("scissors_op.png");
					break;
			}
		}

		private void SetUserImageSource(GameChoice gameChoice) {
			switch (gameChoice) {
				case GameChoice.Rock:
					UserChoiceImage.Source = ImageSource.FromFile ("rock.png");
					break;
				case GameChoice.Paper:
					UserChoiceImage.Source = ImageSource.FromFile ("paper.png");
					break;
				case GameChoice.Scissors:
					UserChoiceImage.Source = ImageSource.FromFile ("scissors.png");
					break;
			}
		}
	}
}

