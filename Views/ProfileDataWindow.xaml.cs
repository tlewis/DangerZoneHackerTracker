using DangerZoneHackerTracker.ProfileData;
using System.Windows;
using System.Windows.Controls;

namespace DangerZoneHackerTracker.Views
{
    /// <summary>
    /// Interaction logic for ProfileDataWindow.xaml
    /// </summary>
    public partial class ProfileDataWindow : Window
	{
		public ProfileDataWindow()
		{
			InitializeComponent();
		}
		public ProfileDataWindow(ProfileData.Profile profile)
		{
			InitializeComponent();
			if(profile is null)
			{
				AddGrid("Loading...", "");
			}
			else
			{
				AddGrid("Privacy State:", profile.privacyState);
				AddGrid("Visibility State:", profile.visibilityState);
				AddGrid("VAC Banned:", profile.vacBanned);
				AddGrid("Trade Banned:", profile.tradeBanState);
				AddGrid("Limited Account:", profile.isLimitedAccount);
				AddGrid("Member Since:", profile.memberSince);
				AddGrid("Hours Past 2 Weeks:", profile.hoursPlayed2Wk);
				AddGrid("Privacy Message:", profile.privacyMessage);
				AddGrid("CSGO Play Time:", profile.GetCSGO()?.hoursOnRecord);
			}
		}

		private void AddGrid(string left, string right)
		{
			var grid = new Grid();
			grid.ColumnDefinitions.Add(new());
			grid.ColumnDefinitions.Add(new());
			var text1 = new TextBlock()
			{
				Text = left,
				HorizontalAlignment = HorizontalAlignment.Left,
			};

			var text2 = new TextBlock()
			{
				Text = right,
				HorizontalAlignment = HorizontalAlignment.Right,
			};

			grid.Children.Add(text1);
			grid.Children.Add(text2);

			Grid.SetColumn(text1, 0);
			Grid.SetColumn(text2, 1);

			OuterStack.Children.Add(grid);
		}
	}
}
