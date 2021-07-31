using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StreamingApp
{
    public partial class MainPage : ContentPage
    {
        bool IsPlaying;
        public MainPage()
        {
            InitializeComponent();
            IsPlaying = false;
            StatusLabel.Text = "Not yet playing";
        }
        private void UpdateUI()
        {
            StatusLabel.Text = IsPlaying ? "Now playing" : "Stopped playing";
        }

        private void PlayButton_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IStreaming>().Play();
            IsPlaying = true;
            UpdateUI();
        }



        private void PauseButton_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IStreaming>().Pause();
            IsPlaying = false;
            UpdateUI();
        }

        private void StopButton_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IStreaming>().Stop();
            IsPlaying = false;
            UpdateUI();
        }
    }
}
