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

    public string WiFiStandardVersion { get; private set; }
    public bool BluetoothModuleHave { get; private set; }
    public string PcieVersion { get; private set; }
    public int PowerConsumption { get; private set; }

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

    public WiFiAdapterBuilder Debuilder()
    {
        return new WiFiAdapterBuilder()
            .WiFiStandardVersion(WiFiStandardVersion)
            .BluetoothModuleHave(BluetoothModuleHave)
            .PcieVersion(PcieVersion)
            .PowerConsumption(PowerConsumption);
    }
}