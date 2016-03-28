using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RockPaperScissors
{
	public partial class ControlsSamplePage : ContentPage
	{
		public ControlsSamplePage ()
		{
			InitializeComponent ();
		}

		private void OnStepperValueChanged(object sender, ValueChangedEventArgs e) {
			StepperValueLabel.Text = "Stepper value: " + TestStepper.Value.ToString();
		}
	}
}

