﻿using FourthLabWorkInSeventhChapters;
using System;

namespace TestFourthLab
{
    public class TestClock : ISystemClock
    {
        public DateTime Now { get; set; } = new DateTime(2022, 2, 20);
    }
}
