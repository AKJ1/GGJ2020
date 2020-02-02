using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ToolSourceInteractable :Interactable
{
    public Tool ToolToGive;

    public static bool CanGiveTool = true;

    public override void InteractStart(PlayerState state)
    {
        if (CanGiveTool)
        {
            state.AddTool(ToolToGive);
            CanGiveTool = false;
            base.InteractStart(state);
        }
    }
}
