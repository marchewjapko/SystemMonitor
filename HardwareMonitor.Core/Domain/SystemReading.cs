﻿using System;

namespace HardwareMonitor.Core.Domain
{
    public class SystemReading
    {
        public int Id { get; set; }
        public SystemInfo SystemInfo { get; set; }
        public Usage Usage { get; set; }
        public SystemSpecs SystemSpecs { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
