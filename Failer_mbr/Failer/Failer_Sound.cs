using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Failer
{
    public partial class Failer_Sound : Form
    {
        private readonly string[] _soundPaths =
        {
            @"C:\Windows\Media\Windows Critical Stop.wav",
            @"C:\Windows\Media\Windows Exclamation.wav",
            @"C:\Windows\Media\Windows Ding.wav",
            @"C:\Windows\Media\chord.wav"
        };
        private readonly SoundPlayer _soundPlayer = new SoundPlayer();
        private readonly Random _random = new Random();
        private readonly System.Timers.Timer _timer = new System.Timers.Timer();

        public Failer_Sound()
        {
            InitializeComponent();
            this.TransparencyKey = this.BackColor;
            _timer.Elapsed += Timer_Elapsed;
        }

        private void PlayRandomSound()
        {
            // Choose a random sound file path that exists
            var availablePaths = _soundPaths.Where(File.Exists).ToList();
            if (availablePaths.Count == 0)
            {
                return;
            }
            var randomPath = availablePaths[_random.Next(availablePaths.Count)];

            // Play the selected sound
            _soundPlayer.SoundLocation = randomPath;
            _soundPlayer.Play();

            // Start the timer to play another random sound after a delay
            _timer.Interval = 500; // 0.5 seconds
            _timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Stop the timer and play another random sound
            _timer.Stop();
            PlayRandomSound();
        }

        private void Failer_Sound_Load(object sender, EventArgs e)
        {
            PlayRandomSound();
            timer1.Start();
            timer2.Start();
            timer3.Start();
        }

        private void Failer_Sound_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
            var NewForm = new Failer_LAST();
            NewForm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
