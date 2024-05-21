using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class stationActivity : MonoBehaviour
{
    public GameObject uiaStation;
    public GameObject dcuStation;
    public GameObject roverStation;
    public GameObject specStation;
    public GameObject commStation;

    public TMP_Text uiaHeader;
    public TMP_Text uiaTime;
    public TMP_Text dcuHeader;
    public TMP_Text dcuTime;
    public TMP_Text roverHeader;
    public TMP_Text roverTime;
    public TMP_Text specHeader;
    public TMP_Text specTime;
    public TMP_Text commHeader;

    public TMP_Text uiaActive;
    public TMP_Text dcuActive;
    public TMP_Text roverActive;
    public TMP_Text specActive;
    public TMP_Text commActive;

    public Image uiaActiveFrame;
    public Image dcuActiveFrame;
    public Image roverActiveFrame;
    public Image specActiveFrame;
    public Image commActiveFrame;

    // station colors
    public Color white      = new Color(255, 255, 255, 255);
    public Color red        = new Color(255, 0, 0, 255);
    public Color green      = new Color(0, 255, 0, 255);
    public Color black      = new Color(0, 0, 0, 255);
    public Color uiaColor   = new Color (255, 0, 0, 255);
    public Color dcuColor   = new Color (0, 255, 0, 255);
    public Color roverColor = new Color (0, 204, 255, 255);
    public Color specColor  = new Color (0, 0, 255, 255);
    public Color commColor  = new Color (157, 83, 255, 255);

    // active bools
    public bool isUiaActive;
    public bool isDcuActive;
    public bool isRoverActive;
    public bool isSpecActive;
    public bool isCommActive;


    // Start is called before the first frame update
    void Start()
    {
        isUiaActive = true;
        isDcuActive = true;
        isRoverActive = true;
        isSpecActive = true;
        isCommActive = true;

    }

    // Update is called once per frame
    void Update()
    {
        // UIA Text Colors
        if(!isUiaActive) {

            setNotActive(uiaTime, uiaActive, uiaActiveFrame);
        }
        else if (isUiaActive) {

            setActive(uiaTime, uiaActive, uiaActiveFrame, uiaColor);
        }

        // DCU Text Colors
        if(!isDcuActive) {

            setNotActive(dcuTime, dcuActive, dcuActiveFrame);
        }
        else if (isDcuActive) {

            setActive(dcuTime, dcuActive, dcuActiveFrame, dcuColor);
        }

        // ROVER Text Colors
        if(!isRoverActive) {

            setNotActive(roverTime, roverActive, roverActiveFrame);
        }
        else if (isRoverActive) {

            setActive(roverTime, roverActive, roverActiveFrame, roverColor);
        }

        // SPEC Text Colors
        if(!isSpecActive) {

            setNotActive(specTime, specActive, specActiveFrame);
        }
        else if (isSpecActive) {

            setActive(specTime, specActive, specActiveFrame, specColor);
        }

        // COMM Text Colors
        if(!isCommActive) {
            commActive.text = "Not Active";
            commActiveFrame.color = red;
        }
        else if (isCommActive) {
            commActive.text = "Active";
            commActive.color = black;
            commActiveFrame.color = green;
        }

        //Update active box colors

        //END Update()
    }

    void setNotActive(TMP_Text timeText, TMP_Text activeText, Image activeFrame) {
        timeText.color = white;
        activeText.text = "Not Active";
        activeText.color = white;
        activeFrame.color = red;
    }

    void setActive(TMP_Text timeText, TMP_Text activeText, Image activeFrame, Color stationColor) {
        timeText.color = stationColor;
        activeText.text = "Active";
        activeText.color = black;
        activeFrame.color = green;
    }
}

