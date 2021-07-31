using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using AVFoundation;
using Xamarin.Forms;
using StreamingApp.iOS;

[assembly: Dependency(typeof(StreamingService))]
namespace StreamingApp.iOS
{
    /// <summary>
    /// Streaming for iOS. Based on https://ilanolkies.com/post/Xamarin-Radio-Streaming-Player
    /// </summary>
    public class StreamingService : IStreaming
    {
        AVPlayer player;
        bool isPrepared;
        string dataSource = "http://pollux.shoutca.st:8132/stream";

        public void Play()
        {
            AVAudioSession.SharedInstance().SetCategory(AVAudioSessionCategory.Playback);
            if (!isPrepared || player == null)
            {
                player = AVPlayer.FromUrl(NSUrl.FromString(dataSource));
            }

            isPrepared = true;
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