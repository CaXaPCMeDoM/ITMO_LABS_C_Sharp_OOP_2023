namespace Itmo.ObjectOrientedProgramming.Lab2.WiFi;

public interface IWiFiAdapterBuilder
{
    WiFiAdapterBuilder WiFiStandardVersion(string wiFiStandardVersion);

    WiFiAdapterBuilder BluetoothModuleHave(bool bluetoothModuleHave);

    WiFiAdapterBuilder PcieVersion(string pcieVersion);

    WiFiAdapterBuilder PowerConsumption(int powerConsumption);

    WiFiAdapter Build();
}