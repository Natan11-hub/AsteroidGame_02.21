﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WpfApp1.ViewModels.Base;

namespace WpfApp1.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private Timer _Timer;
        public string Title { get; set; } = "Заголовок окна проекта MVVM";

        private DateTime _CurrentTime;

        public DateTime CurrentTime
        {
            get => _CurrentTime;
            set
            {
                if (Equals(_CurrentTime, value)) return;
                _CurrentTime = value;
                OnPropertyChanged();
            }
        }

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
