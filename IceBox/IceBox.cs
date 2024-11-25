using IceBox.Windows;
using ECommons.SimpleGui;
using ECommons.Automation.NeoTaskManager;

namespace IceBox;

// note to myself whenever I look back at this, P.TaskManager... came from this.
// "Plugin" Or whatever the name of the plugin is, is the name RIGHT BELOW THIS. 
// So if you change it to SushiRoll, it would be Name "SushiRoll" -> internal static SushiRoll P.
public sealed class IceBox : IDalamudPlugin
{
    public static TaskManager TaskManagerIce;
    private const string CommandName = "/pmycommand";
    public IceBox(IDalamudPluginInterface pluginInterface)
    {
        pluginInterface.Create<Service>();
        Service.IceBox = this;
        Service.Configuration = pluginInterface.GetPluginConfig() as Config ?? new Config();
        ECommonsMain.Init(pluginInterface, this);
        TaskManagerIce = new();
        EzConfigGui.Init(new MainWindow().Draw);
        EzConfigGui.WindowSystem.AddWindow(new SettingsWindow());
        EzCmd.Add(CommandName, OnCommand, "Open Interface");
        Svc.Framework.Update += Tick;
    }

    // this is to (what I'm assume) constantly have the plugin check for any actions. 
    // It looks like this manages all the tick states of anything else that I have running, (esentially a good safety net to make sure that it doens't try and do shit while you're TP'ing for instance
    private void Tick(object _) 
    {
        if (SchedulerMain.PluginEnabled && Svc.ClientState.LocalPlayer != null)
        {
            SchedulerMain.Tick();
        }
    }

    public void Dispose()
    {
        Safe(() => Svc.Framework.Update -= Tick);
        ECommonsMain.Dispose();
    }

    private void OnCommand(string command, string args)
    {
        EzConfigGui.Window.IsOpen = !EzConfigGui.Window.IsOpen;
    }
}
