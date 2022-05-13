using NAudio.Wave;
using System.Reflection;

namespace DangerZoneHackerTracker
{
    class SoundManager
	{
		public static void PlayEmbeddedSound(string name, float volume)
		{
			var stream = Assembly.GetExecutingAssembly()
								 .GetManifestResourceStream("DangerZoneHackerTracker.Resources." + name);
			var outputDevice = new WaveOutEvent();
			var audioFile = new Mp3FileReader(stream);
			outputDevice.Volume = volume;
			outputDevice.PlaybackStopped += (object sender, StoppedEventArgs e) =>
			{
				audioFile.Dispose();
				audioFile = null;
				stream.Dispose();
				stream = null;
				outputDevice.Dispose();
				outputDevice = null;
			};

			outputDevice.Init(audioFile);
			outputDevice.Play();
		}
	}
}
