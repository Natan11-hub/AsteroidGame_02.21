﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Infrastructrure.Commands.Base;

namespace WpfApp1.Infrastructrure.Commands
{
    class LambdaCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;
        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            if (Execute is null)
                throw new ArgumentNullException(nameof(Execute));
            _Execute = Execute;
            _CanExecute = CanExecute;
        }

        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;
        public override void Execute(object parameter) => Execute(parameter);
    }
}
