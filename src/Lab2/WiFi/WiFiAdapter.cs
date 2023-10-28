namespace Itmo.ObjectOrientedProgramming.Lab2.WiFi;

public class WiFiAdapter
{
    public WiFiAdapter(string wiFiStandardVersion, bool bluetoothModuleHave, string pcieVersion, int powerConsumption)
    {
        WiFiStandardVersion = wiFiStandardVersion;
        BluetoothModuleHave = bluetoothModuleHave;
        PcieVersion = pcieVersion;
        PowerConsumption = powerConsumption;
    }

    public string WiFiStandardVersion { get; set; }
    public bool BluetoothModuleHave { get; set; }
    public string PcieVersion { get; set; }
    public int PowerConsumption { get; set; }

    public WiFiAdapter Clone()
    {
        return new WiFiAdapter(
            WiFiStandardVersion,
            BluetoothModuleHave,
            PcieVersion,
            PowerConsumption)
        {
            WiFiStandardVersion = WiFiStandardVersion,
            PowerConsumption = PowerConsumption,
            BluetoothModuleHave = BluetoothModuleHave,
            PcieVersion = PcieVersion,
        };
    }
}