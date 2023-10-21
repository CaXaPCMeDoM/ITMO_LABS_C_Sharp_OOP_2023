namespace Itmo.ObjectOrientedProgramming.Lab2.WiFi;

public class WiFiAdapterBuilder : IWiFiAdapterBuilder
{
    internal WiFiAdapterBuilder()
    {
        WiFiAdapter = new WiFiAdapter();
    }

    private WiFiAdapter WiFiAdapter { get; set; }

    public WiFiAdapterBuilder WiFiStandardVersion(string wiFiStandardVersion)
    {
        WiFiAdapter.WiFiStandardVersion = wiFiStandardVersion;
        return this;
    }

    public WiFiAdapterBuilder BluetoothModuleHave(bool bluetoothModuleHave)
    {
        WiFiAdapter.BluetoothModuleHave = bluetoothModuleHave;
        return this;
    }

    public WiFiAdapterBuilder PcieVersion(string pcieVersion)
    {
        WiFiAdapter.PcieVersion = pcieVersion;
        return this;
    }

    public WiFiAdapterBuilder PowerConsumption(int powerConsumption)
    {
        WiFiAdapter.PowerConsumption = powerConsumption;
        return this;
    }

    public WiFiAdapter Build()
    {
        return WiFiAdapter;
    }
}