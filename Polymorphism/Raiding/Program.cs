﻿using System;
using Raiding.Core;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();

            engine.Start();
        }
    }
}
