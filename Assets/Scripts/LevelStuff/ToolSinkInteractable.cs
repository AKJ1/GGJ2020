using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UniRx;

public class ToolSinkInteractable : Interactable, IBreakable
{
    public bool IsBroken { get; private set; } = false;

    public Tool ToolToTake;

    public bool ConsumeTool = true;

    protected Color rightfulColor = Color.white;

    private void Awake()
    {
        RegisterBreakable();
    }

    public void Break()
    {
        if (!IsBroken)
        {
            GameState.Instance.BrokenItems++;
            rightfulColor = Color.magenta;
            gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.magenta);
            IsBroken = true;
        }
    }

    public void Fix()
    {
        if (IsBroken)
        {
            GameState.Instance.BrokenItems--;
            rightfulColor = Color.white;
            IsBroken = false;
        }
    }

    public override void InteractStart(PlayerState state)
    {
        if (IsBroken && state.HasTool(ToolToTake))
        {
            Fix();
            if (ConsumeTool)
            {
                state.RemoveTool(ToolToTake);
            }
            gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.green);
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.yellow);
        }
    }

    public override void InteractStop()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", rightfulColor);
    }

    public void RegisterBreakable()
    {
        GameState.Instance.RegisteredBreakables++;
    }
}
