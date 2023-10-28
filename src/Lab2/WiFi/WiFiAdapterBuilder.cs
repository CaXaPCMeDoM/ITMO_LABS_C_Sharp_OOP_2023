namespace Itmo.ObjectOrientedProgramming.Lab2.WiFi;

public class WiFiAdapterBuilder : IWiFiAdapterBuilder
{
    private string _wiFiStandardVersion = string.Empty;
    private bool _bluetoothModuleHave;
    private string _pcieVersion = string.Empty;
    private int _powerConsumption;

    public WiFiAdapterBuilder WiFiStandardVersion(string wiFiStandardVersion)
    {
        _wiFiStandardVersion = wiFiStandardVersion;
        return this;
    }

    public WiFiAdapterBuilder BluetoothModuleHave(bool bluetoothModuleHave)
    {
        _bluetoothModuleHave = bluetoothModuleHave;
        return this;
    }

    public WiFiAdapterBuilder PcieVersion(string pcieVersion)
    {
        _pcieVersion = pcieVersion;
        return this;
    }

    public WiFiAdapterBuilder PowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public WiFiAdapter Build()
    {
        return new WiFiAdapter(
            _wiFiStandardVersion,
            _bluetoothModuleHave,
            _pcieVersion,
            _powerConsumption);
    }
}