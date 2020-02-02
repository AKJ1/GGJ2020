using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public virtual void InteractStart(PlayerState state)
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.red);
    }

    public virtual void InteractStop()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.white);
    }
}
