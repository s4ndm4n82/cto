namespace cto.Classes;

public class GlobalAppSettings
{
    private static readonly Lazy<GlobalAppSettings> GlobalInstance = new Lazy<GlobalAppSettings>(() => new GlobalAppSettings());
    
    public static GlobalAppSettings Instance => GlobalInstance.Value;
    
    public AppSettingsClass? Settings { get; private set; }
    
    private GlobalAppSettings() { }
    
    public void UpdateSettings(AppSettingsClass settings)
    {
        Settings = settings;
    }
}