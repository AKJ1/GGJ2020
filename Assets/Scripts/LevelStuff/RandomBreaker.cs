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
        Breakables = new List<IBreakable>();
        var objs = GameObject.FindObjectsOfType<GameObject>();
        for (int i = 0; i < objs.Length; i++)
        {
            if(objs[i].GetComponent<IBreakable>() != null)
            {
                Breakables.Add(objs[i].GetComponent<IBreakable>());
            }
        }
        ResetTimer();
    }
    
    void ResetTimer()
    {
        var delaySecs = Random.Range(MinMaxBreakInterval.x, MinMaxBreakInterval.y);
        CurrentBreakTime = delaySecs;
        var delaySpan = TimeSpan.FromSeconds(delaySecs);
        Observable.Timer(delaySpan).Do(_ =>
        {
            Breakables[Random.Range(0, Breakables.Count)].Break();
            ResetTimer();
        }).Subscribe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
