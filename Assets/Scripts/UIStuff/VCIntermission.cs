using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class VCIntermission : MonoBehaviour 
{
    public EventTrigger Trigger;

    protected bool CanBeClicked;

    public void Start()
    {
        var trigger = gameObject.GetComponent<EventTrigger>();
        if(trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();
        }

        EventTrigger.Entry press = new EventTrigger.Entry();
        press.eventID = EventTriggerType.PointerClick;
        press.callback.AddListener((_) => OnPress());

        trigger.triggers.Add(press);
    }

    public void DisplayIntermission()
    {


    }

    public void OnPress()
    {
        CanBeClicked = false;
        Hide();
        GameState.Reset();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Show()
    {
        CanBeClicked = true;
        Toggle(true);
    }

    public void Hide()
    {
        Toggle(false);
    }

    public void Toggle(bool targetState)
    {
        this.gameObject.SetActive(targetState);
    }
}
