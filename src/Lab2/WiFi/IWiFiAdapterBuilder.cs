namespace Itmo.ObjectOrientedProgramming.Lab2.WiFi;

public interface IWiFiAdapterBuilder
{
    public WiFiAdapterBuilder WiFiStandardVersion(string wiFiStandardVersion);

    public WiFiAdapterBuilder BluetoothModuleHave(bool bluetoothModuleHave);

    public WiFiAdapterBuilder PcieVersion(string pcieVersion);

    public WiFiAdapterBuilder PowerConsumption(int powerConsumption);

    public WiFiAdapter Build();
}