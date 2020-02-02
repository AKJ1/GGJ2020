using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangerBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    public void Update()
    {
        slider.normalizedValue = GameState.Instance.DangerLevel;
    }
}
