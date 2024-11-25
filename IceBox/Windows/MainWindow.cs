using System.Drawing;
using System.Reflection;
using ECommons.SimpleGui;
using FFXIVClientStructs.FFXIV.Common.Configuration;
using IceBox.Scheduler.Handlers;

namespace IceBox.Windows;

internal class MainWindow : ConfigWindow, IDisposable
{   
    private const string LogoManifestResource = "Ice_Box.Data.Portrit.png";
    private const uint SidebarWindowWidth = 203;
    private Point logoSize = new(210, 203);
    private const float LogoScale = 1f;

    public MainWindow() :base() 
    {
        Flags = ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse | ImGuiWindowFlags.NoCollapse;
        SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(100, 100),
            MaximumSize = new Vector2(800, 600)
        };
    }

    public void Dispose() { }

    bool configValue = false;
    public override void Draw()
    {
        
        if (Svc.Texture.GetFromManifestResource(Assembly.GetExecutingAssembly(), LogoManifestResource).TryGetWrap(out var logo, out var _))
        {
            var maxWidth = 375 * 2 * 0.85f * ImGuiHelpers.GlobalScale;
            var ratio = maxWidth / logoSize.X;
            var scaledLogoSize = new Vector2(logoSize.X * LogoScale, logoSize.Y * LogoScale);
            ImGui.Image(logo.ImGuiHandle, scaledLogoSize);
        }
        else
        {
            ImGui.Text("Image not found.");
        }
        ImGui.Spacing();
        if (ImGuiEx.IconButton(FontAwesomeIcon.Wrench, "Settings"))
            EzConfigGui.WindowSystem.Windows.FirstOrDefault(w => w.WindowName == SettingsWindow.WindowName)!.IsOpen ^= true;
        bool isRunning = SchedulerMain.PluginEnabled;

        if (ImGui.Button(isRunning ? "Stop" : "Start"))
        {
            // Toggle the state
            isRunning = !isRunning;

            // Apply the state to your service
            SchedulerMain.IsEnabled = isRunning;
        }
        // ImGui.TextColored(Example.enabled ? new Vector4(0.0f, 1.0f, 0.0f, 1.0f) : new Vector4(1.0f, 0.0f, 0.0f, 1.0f), $"Are we working: {(Example.enabled ? "Yes" : "No")}");
    }
}
