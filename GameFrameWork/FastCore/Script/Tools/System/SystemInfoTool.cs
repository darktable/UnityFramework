using FastFrameWork;
using UnityEngine;

public class SystemInfoTool
{
    public enum SystemInfoNames
    {
        /// <summary>设备ID</summary>
        bundleidentifier,
        /// <summary>版本号</summary>
        version,
        devicemodel,
        devicename,
        deviceuniqueidentifier,
        graphicsdevicename,
        graphicsmemorysize,
        graphicsmultithreaded,
        operatingsystem,
        processorcount,
        processortype,
        systemmemorysize,
        developerbuild,
        rsmodel,
        all
    }
    
    public static string GetSysInfo(SystemInfoNames name)
    {
        return GetSysInfo(name.ToString());
    }
    public static string GetSysInfo(string name)
    {
        bool isall = false;
        name = name.ToLower();
        if (name == "all") isall = true;
        string str = "";
        
        if (isall || name == "bundleidentifier") str = isall ? str + Application.identifier + "\n" : Application.identifier;
        if (isall || name == "version") str = isall ? str + Application.version + "\n" : Application.version;
        if (isall || name == "devicemodel") str = isall ? str + SystemInfo.deviceModel + "\n" : SystemInfo.deviceModel;
        if (isall || name == "devicename") str = isall ? str + SystemInfo.deviceName + "\n" : SystemInfo.deviceName;
        if (isall || name == "deviceuniqueidentifier") str = isall ? str + SystemInfo.deviceUniqueIdentifier + "\n" : SystemInfo.deviceUniqueIdentifier;
        if (isall || name == "graphicsdevicename") str = isall ? str + SystemInfo.graphicsDeviceName + "\n" : SystemInfo.graphicsDeviceName;
        if (isall || name == "graphicsmemorysize") str = isall ? str + SystemInfo.graphicsMemorySize.ToString() + "\n" : SystemInfo.graphicsMemorySize.ToString();
        if (isall || name == "graphicsmultithreaded") str = isall ? str + SystemInfo.graphicsMultiThreaded.ToString() + "\n" : SystemInfo.graphicsMultiThreaded.ToString();
        if (isall || name == "operatingsystem") str = isall ? str + SystemInfo.operatingSystem + "\n" : SystemInfo.operatingSystem;
        if (isall || name == "processorcount") str = isall ? str + SystemInfo.processorCount.ToString() + "\n" : SystemInfo.processorCount.ToString();
        if (isall || name == "processortype") str = isall ? str + SystemInfo.processorType + "\n" : SystemInfo.processorType;
        if (isall || name == "systemmemorysize") str = isall ? str + SystemInfo.systemMemorySize.ToString() + "\n" : SystemInfo.systemMemorySize.ToString();
        if (isall || name == "developerbuild") str = isall ? str + Application.installMode.ToString() + "\n" : Application.installMode.ToString();
        return str;
    }
}
