﻿using System.Threading.Tasks;

namespace Modular.Monolithic.Architecture.Helper
{
    public class Class1
    {

        public async Task GetValue() => await Task.Delay(100);

        public async Task GetValue2() => await Task.Delay(100);
    }
}
