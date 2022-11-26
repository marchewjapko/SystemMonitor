﻿using DataSource.Usage.Windows.DataRetrieval;
using SharedObjects;
using System.Runtime.Versioning;

namespace DataSource.Usage.Windows
{
    [SupportedOSPlatform("windows")]
    public class UsageMonitorWindows
    {
        private CpuInfo cpuInfo;
        private DiskInfo diskInfo;
        private MemoryInfo memoryInfo;
        private NetworkInfo networkInfo;
        private SystemInfo systemInfo;

        public UsageMonitorWindows()
        {
            Parallel.Invoke(
                () => { cpuInfo = new CpuInfo(); },
                () => { memoryInfo = new MemoryInfo(); },
                () => { diskInfo = new DiskInfo(); },
                () => { networkInfo = new NetworkInfo(); },
                () => { systemInfo = new SystemInfo(); },
                () => { systemInfo = new SystemInfo(); }
            );
        }

        public CreateUsage GetSystemUsage()
        {
            Parallel.Invoke(
                () => { diskInfo.UpdateDiskInstances(); },
                () => { networkInfo.UpdateNetworkInstances(); }
            );
            return new CreateUsage()
            {
                CpuTotalUsage = cpuInfo.GetCpuTotalUsage(),
                CpuPerCoreUsage = cpuInfo.GetCpuPerCoreUsage(),
                DiskUsage = diskInfo.GetDiskUsage(),
                MemoryUsage = memoryInfo.GetRemainingMemory(),
                BytesReceived = networkInfo.GetBytesReceived(),
                BytesSent = networkInfo.GetBytesSent(),
                SystemUptime = systemInfo.GetSystemUptime(),
            };
        }
    }
}
