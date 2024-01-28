using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class buttonBehaviour : MonoBehaviour
{
    public GameObject Panel;
    private bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        Panel.SetActive(isOn);
    }

    public void OnButtonPress()
    {
        isOn = !isOn;
        Panel.SetActive(isOn);
    }
}
