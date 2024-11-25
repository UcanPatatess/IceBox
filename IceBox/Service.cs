using Dalamud.Plugin;
using ECommons.Automation.NeoTaskManager;

namespace IceBox
{
    internal class Service
    {
        
        internal static IceBox IceBox { get; set; } = null!;
        internal static Config Configuration { get; set; } = null!;
        public static IDalamudPluginInterface PluginInterface { get; set; } = null!;
    }
}
