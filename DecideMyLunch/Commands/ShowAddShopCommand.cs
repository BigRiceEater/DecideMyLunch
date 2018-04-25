﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands
{
    public class ShowAddShopCommand : ShowCommand
    {
        public ShowAddShopCommand(MainViewModel vm) : base(vm) {}

        public override void Execute(object parameter)
        {
            _vm?.ShowAddShop();
        }
    }
}
