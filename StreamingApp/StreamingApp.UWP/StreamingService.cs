using StreamingApp.UWP;
using System;
using Windows.Media.Core;
using Windows.Media.Playback;
using Xamarin.Forms;

[assembly: Dependency(typeof(StreamingService))]
namespace StreamingApp.UWP
{
    /// <summary>
    /// Streaming service for UWP. Based on https://ilanolkies.com/post/Xamarin-Radio-Streaming-Player
    /// and https://docs.microsoft.com/en-us/windows/uwp/audio-video-camera/adaptive-streaming
    /// </summary>
    public class StreamingService : IStreaming
    {
        MediaPlayer player;
        bool isPrepared = false;
        string dataSource = "http://pollux.shoutca.st:8132/stream";
        public void Play()
        {
            if (!isPrepared || player == null)
            {
                player = new MediaPlayer();
                player.Source = MediaSource.CreateFromUri(new Uri(dataSource));
                isPrepared = true;
            }
            player.Play();
        }

        public void Pause()
        {
            player.Pause();
        }

        public void Stop()
        {
            player.Dispose();
            isPrepared = false;
        }
    }
}
