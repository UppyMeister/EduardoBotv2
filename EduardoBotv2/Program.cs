﻿using System.Threading.Tasks;
using EduardoBotv2.Core;

namespace EduardoBotv2
{
    public sealed class Program
    {
        public static async Task Main(string[] args)
        {
            await new EduardoBot().RunAsync();
        }
    }
}