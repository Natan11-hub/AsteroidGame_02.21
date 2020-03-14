﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WpfApp1.ViewModels
{
    class MainWindowViewModel
    {
        private Timer _Timer;
        public string Title { get; set; } = "Заголовок окна проекта MVVM";

        public DateTime CurrentTime { get; set; }

        public MainWindowViewModel()
        {
            _Timer = new Timer(100) { AutoReset = true };       
            _Timer.Elapsed += OnTimerTick;
            _Timer.Start();
        }
        private void OnTimerTick(object Sender, ElapsedEventArgs E)
        {
            CurrentTime = DateTime.Now;
        }
    }
}