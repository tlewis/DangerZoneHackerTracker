﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DangerZoneHackerTracker
{

    /// <summary>
    /// Interaction logic for BulkAddWindow.xaml
    /// </summary>
    public partial class BulkAddWindow
	{
		List<string> ReturnLines;
		static Settings Settings = Settings.Init();
		static CheaterSet Cheaters = CheaterSet.Init();
		static HashSet<Cheater> TempCheaters = new();

		public BulkAddWindow()
		{
			InitializeComponent();
			TempCheaters.Clear();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			// Get each line in the text box and put it in a list
			var lines = TxtBox.Text.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
			ReturnLines = new List<string>(lines);
			
			// Wipe it early so that it looks like we're faster than we actually are.
			TxtBox.Text = "";

			// for every line in the text box we run it through the ReadLine function
			var taskList = new List<Task>();
			foreach (var line in lines)
			{
				var task = Task.Run(() => ReadLine(line));
				taskList.Add(task);
			}

			// We create a new Task for when all of the tasks in our task list are completed.
			Task.WhenAll(taskList).Wait();

			foreach(var chet in TempCheaters)
			{
				Cheaters.Add(chet);
				ToastManager.ShowToastAsync("Successfully Added Cheater",
					$"Cheater {chet.LastKnownName} has been added to the hacker tracker",
				Notifications.Wpf.Core.NotificationType.Success);
			}

			// recreate the list with any values that couldn't be parsed.
			TxtBox.Text = string.Join('\n', ReturnLines);
			if(TxtBox.Text.Length != 0 && !string.IsNullOrWhiteSpace(TxtBox.Text))
			{
				TxtBlockWarning.Visibility = Visibility.Visible;
			}

			TempCheaters.Clear();
		}

		private async Task ReadLine(string line)
		{
			try
			{

				string url;
				var steam = new SteamID(0);
				if (!SteamID.CommunityURLRegex.IsMatch(line))
				{
					if (!steam.SetFromString(line) && !steam.SetFromSteam3String(line))
					{
						return;
					}
					url = $"https://steamcommunity.com/profiles/{steam.ConvertToUInt64()}/?xml=1";
				}
				else
				{
					url = $"{SteamID.CommunityURLRegex.Match(line).Value}/?xml=1";
				}

				var data = await Steam.GetProfileDataAsync(url);



				Cheater cheater = new()
				{
					AccountID = Convert.ToUInt64(data.steamID64),
					CheatList = "<Bulk Added User>",
					LastKnownName = data.steamID,
					Submitter = Settings["UserNameOverride"],
					ThreatLevel = -1
				};

				TempCheaters.Add(cheater);
				ReturnLines.Remove(line);
			}
			catch (Exception)
			{
			}
		}

		

		private void TxtBox_GotFocus(object sender, RoutedEventArgs e)
		{
			if(TxtBox.Text == "https://steamcommunity.com/id/kidfearless/")
			{
				TxtBox.Text = "";
			}
		}

		private void TxtBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if(TxtBox.Text == "")
			{
				TxtBox.Text = "https://steamcommunity.com/id/kidfearless/";
			}
		}

		private void TxtBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
		{
			if (TxtBox.Text == "https://steamcommunity.com/id/kidfearless/")
			{
				TxtBox.Text = "";
			}
		}

		private void TxtBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
		{
			if (TxtBox.Text == "")
			{
				TxtBox.Text = "https://steamcommunity.com/id/kidfearless/";
			}
		}

		private void TxtBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if(!this.IsInitialized)
			{
				return;
			}
			if (TxtBox.Text == "")
			{
				TxtBlockWarning.Visibility = Visibility.Hidden;
				BtnAdd.IsEnabled = false;
			}
			else
			{
				BtnAdd.IsEnabled = true;
			}
		}

		private void BiaWindow_MouseDown(object sender, MouseButtonEventArgs e)
		{
		}
	}
}
