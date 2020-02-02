using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameState
{
    public static GameState Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameState();
            }
            return _instance;
        }
    }

    private static GameState _instance;

    public int BrokenItems;

    public int RegisteredBreakables;

    public float DangerLevel => (BrokenItems / (float)RegisteredBreakables);

    public static void Reset()
    {
        _instance = new GameState();
    }

}
