using Android.Media;
using StreamingApp.Droid;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(StreamingService))]
namespace StreamingApp.Droid
{
    /// <summary>
    /// Streaming for Android. Based on https://ilanolkies.com/post/Xamarin-Radio-Streaming-Player
    /// </summary>
    public class StreamingService : IStreaming
    {
        MediaPlayer player;
        //Tell our player to stream music
        bool IsPrepared = false;
        string dataSource = "http://pollux.shoutca.st:8132/stream";

        public void Play()
        {
            if (IsPrepared)
            {
                player.Start();
            }
            else
            {
                if (player == null)
                {
                    player = new MediaPlayer();
                    player.Error += (sender, args) =>
                    {
                        //playback error
                        Console.WriteLine("Error in playback resetting: " + args.What);
                        Stop();//this will clean up and reset properly.
                    };
                    player.Prepared += (sender, args) =>
                    {
                        Console.WriteLine("@@@ Starting player...");
                        player.Start();
                        IsPrepared = true;
                    };
                }
                else
                {
                    player.Reset();
                }

                player.SetDataSource(dataSource);
                player.PrepareAsync();
            }
        }

        public void Pause()
        {
            player.Pause();
        }

        public void Stop()
        {
            player.Stop();
            IsPrepared = false;
        }
    }
}