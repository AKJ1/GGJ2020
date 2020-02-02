using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;
using System;
using UniRx;
using System.Linq;

public class RandomBreaker : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 MinMaxBreakInterval;
    public float CurrentBreakTime;

    public List<IBreakable> Breakables;

    void Start()
    {
        ResetTimer();
    }

    void ReenumerateBreakables()
    {
        Breakables = new List<IBreakable>();
        var objs = GameObject.FindObjectsOfType<GameObject>();
        for (int i = 0; i < objs.Length; i++)
        {
            if(objs[i].GetComponent<IBreakable>() != null)
            {
                if (!objs[i].GetComponent<IBreakable>().IsBroken)
                {
                    Breakables.Add(objs[i].GetComponent<IBreakable>());
                }
            }
        }
    }
    
    void ResetTimer()
    {
        var delaySecs = Random.Range(MinMaxBreakInterval.x, MinMaxBreakInterval.y);
        CurrentBreakTime = delaySecs;
        var delaySpan = TimeSpan.FromSeconds(delaySecs);
        Observable.Timer(delaySpan).Do(_ =>
        {
            ReenumerateBreakables();
            var chosen = Breakables[Random.Range(0, Breakables.Count - 1)];
            chosen.Break();
            ResetTimer();
        }).Subscribe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
