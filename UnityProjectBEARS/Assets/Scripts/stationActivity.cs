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

    // Complete variables
    public Image uiaCompleteFrame;
    public Image dcuCompleteFrame;
    public Image roverCompleteFrame;
    public Image specCompleteFrame;

    public TMP_Text uiaCompleteText;
    public TMP_Text dcuCompleteText;
    public TMP_Text roverCompleteText;
    public TMP_Text specCompleteText;

    // station colors
    public Color white;
    public Color red;
    public Color green;
    public Color black;
    public Color uiaColor;
    public Color dcuColor;
    public Color roverColor;
    public Color specColor;
    public Color commColor;

    // active bools
    public bool isUiaActive;
    public bool isDcuActive;
    public bool isRoverActive;
    public bool isSpecActive;
    public bool isCommActive;

    // complete bools
    public bool isUiaComplete;
    public bool isDcuComplete;
    public bool isRoverComplete;
    public bool isSpecComplete;

    // Start is called before the first frame update
    void Start()
    {
        // Color initialization
        white      = new Color32(255, 255, 255, 255);
        red        = new Color32(255, 0, 0, 255);
        green      = new Color32(0, 255, 0, 255);
        black      = new Color32(0, 0, 0, 255);
        uiaColor   = new Color32(255, 133, 10, 255);
        dcuColor   = new Color32(202, 202, 170, 255);
        roverColor = new Color32(0, 204, 255, 255);
        specColor  = new Color32(255, 255, 0, 255);
        commColor  = new Color32(157, 83, 255, 255);
        
        // active bool initialization
        isUiaActive     = false;
        isDcuActive     = false;
        isRoverActive   = false;
        isSpecActive    = false;
        isCommActive    = false;

        // complete bool initialization
        isUiaComplete   = false;
        isDcuComplete   = false;
        isRoverComplete = false;
        isSpecComplete  = false;

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

        // ==== Update complete box colors ====
        // UIA Text Colors
        if(!isUiaComplete) {

            setNotComplete(uiaCompleteFrame, uiaCompleteText);
        }
        else if (isUiaComplete) {

            setComplete(uiaCompleteFrame, uiaCompleteText);
        }

        // DCU Text Colors
        if(!isDcuComplete) {

            setNotComplete(dcuCompleteFrame, dcuCompleteText);
        }
        else if (isDcuComplete) {

            setComplete(dcuCompleteFrame, dcuCompleteText);
        }

        // ROVER Text Colors
        if(!isRoverComplete) {

            setNotComplete(roverCompleteFrame, roverCompleteText);
        }
        else if (isRoverComplete) {

            setComplete(roverCompleteFrame, roverCompleteText);
        }

        // SPEC Text Colors
        if(!isSpecComplete) {

            setNotComplete(specCompleteFrame, specCompleteText);
        }
        else if (isSpecComplete) {

            setComplete(specCompleteFrame, specCompleteText);
        }

        //END Update()
    }

    // set Active and Not Active methods
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

    // set complete and not complete methods
    void setNotComplete(Image completeFrame, TMP_Text completeText) {
        completeFrame.color = red;
        completeText.text = "Not complete";
        completeText.color = white;
    }

    void setComplete(Image completeFrame, TMP_Text completeText) {
        completeFrame.color = green;
        completeText.text = "Complete";
        completeText.color = black;
    }
}

