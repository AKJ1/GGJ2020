using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerInteraction : MonoBehaviour
{
    public static string InteractableTag = "Interactable";

    public bool IsInteracting;

    public UnityEvent<GameObject> OnInteractableEnter;
    public UnityEvent<GameObject> OnInteractableExit;

    private void OnTriggerEnter(Collider other)
    {
        //if (!IsInteracting)
        //{
        //    IsInteracting = true;
            if (other.tag == InteractableTag)
            {
                var otherInteractable = other.GetComponent<Interactable>();
                if (otherInteractable != null)
                {
                    otherInteractable.InteractStart(GetComponent<PlayerState>());
                    OnInteractableEnter?.Invoke(other.gameObject);
                }
            }
        //}
    }
    private void OnTriggerExit(Collider other)
    {
        //if (IsInteracting)
        //{
        //    IsInteracting = false;
            if (other.tag == InteractableTag)
            {
                var otherInteractable = other.GetComponent<Interactable>();
                if (otherInteractable != null)
                {
                    //Do shit
                    otherInteractable.InteractStop();
                    OnInteractableExit?.Invoke(other.gameObject);
                }
            }
        //}
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
