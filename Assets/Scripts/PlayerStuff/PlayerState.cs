using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public Dictionary<Tool, bool> ToolAvailabilty;

    private void Awake()
    {
        ToolAvailabilty = new Dictionary<Tool, bool>();
    }

    public void AddTool(Tool tool)
    {
        if( ToolAvailabilty.ContainsKey(tool))
        {
            ToolAvailabilty[tool] = true;
        }
        else { ToolAvailabilty.Add(tool, true); }
        Debug.Log($"GOT TOOL :{tool}");
    }

    public void RemoveTool(Tool tool)
    {
        if(ToolAvailabilty.ContainsKey(tool))
        {
            ToolAvailabilty[tool] = false;
        }
        Debug.Log($"LOST TOOL :{tool}");
    }

    public bool HasTool(Tool tool)
    {
        if(ToolAvailabilty.ContainsKey(tool))
        {
            return ToolAvailabilty[tool];
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum Tool
{
    Hammer, None
}
 