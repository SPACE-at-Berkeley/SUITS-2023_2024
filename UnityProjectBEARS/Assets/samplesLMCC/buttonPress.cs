using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class buttonPress : MonoBehaviour
{
    public GameObject finalCard;
    private bool isShowing;
    private GameObject currentPanel;

    //public GameObject emptyObjectButtons;

    ///void Start()
    //{
    //
    //}

    public void HouseKeeping()
    {
        isShowing = false;
        finalCard.SetActive(isShowing);
    }

    public void OnButtonPress()
    {
        isShowing = !isShowing;
        finalCard.SetActive(isShowing);
        //emptyObjectButtons.GetComponent<IsFinalCardsShowing>().setMaxView();

    }

    //public void exitApp()
    //{
    //    Application.Quit();
    //}

    //public bool getIsShowing()
    //{
    //    return isShowing;
    //}
}
