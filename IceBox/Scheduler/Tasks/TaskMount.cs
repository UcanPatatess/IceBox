using IceBox.Scheduler.Handlers;

namespace IceBox.Scheduler.Tasks;

public class TaskMount
{
    internal static void Enqueue()
    {
        IceBox.TaskManagerIce.Enqueue(TEST.Test);
        //IceBox.TaskManagerIce.Enqueue(PlayerHandlers.PlayerMounted);
    }
}
