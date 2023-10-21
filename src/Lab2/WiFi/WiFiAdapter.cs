namespace Itmo.ObjectOrientedProgramming.Lab2.WiFi;

public class WiFiAdapter
{
    public string WiFiStandardVersion { get; set; } = string.Empty;
    public bool BluetoothModuleHave { get; set; }
    public string PcieVersion { get; set; } = string.Empty;
    public int PowerConsumption { get; set; }

    public WiFiAdapter Clone()
    {
        return new WiFiAdapter()
        {
            WiFiStandardVersion = WiFiStandardVersion,
            PowerConsumption = PowerConsumption,
            BluetoothModuleHave = BluetoothModuleHave,
            PcieVersion = PcieVersion,
        };
    }
}