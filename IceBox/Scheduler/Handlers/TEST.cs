using Dalamud.Game.ClientState.Conditions;
using ECommons.GameHelpers;
using FFXIVClientStructs.FFXIV.Client.Game;
using Lumina.Excel.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceBox.Scheduler.Handlers
{
    internal static unsafe class TEST
    {
        internal static bool? Test()
        {
            GenericHandlers.Throttle(100);
            Svc.Chat.Print("Test12");
            Svc.Chat.Print("499488");
            return true;
        }
    }
}
