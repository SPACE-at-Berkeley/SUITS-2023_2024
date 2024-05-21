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

    // station colors
    public Color white      = new Color(255, 255, 255, 255);
    public Color uiaColor   = new Color (255, 0, 0, 255);
    public Color dcuColor   = new Color (0, 255, 0, 255);
    public Color roverColor = new Color (0, 204, 255, 255);
    public Color specColor  = new Color (255, 255, 0, 255);
    public Color commColor  = new Color (157, 83, 255, 255);


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(uiaActive.text == "Not active") {
            uiaHeader.color = white;
            uiaTime.color   = white;
        }
        else if (uiaActive.text == "Active") {
            uiaHeader.color = uiaColor;
            uiaTime.color   = uiaColor;
        }
        if(dcuActive.text == "Not active") {
            dcuHeader.color = white;
            dcuTime.color   = white;
        }
        else if (dcuActive.text == "Active") {
            dcuHeader.color = dcuColor;
            dcuTime.color   = dcuColor;
        }
        if(roverActive.text == "Not active") {
            roverHeader.color = white;
            roverTime.color   = white;
        }
        else if (roverActive.text == "Active") {
            roverHeader.color = roverColor;
            roverTime.color   = roverColor;
        }
        if(specActive.text == "Not active") {
            specHeader.color = white;
            specTime.color   = white;
        }
        else if (specActive.text == "Active") {
            specHeader.color = specColor;
            specTime.color   = specColor;
        }
        if(commActive.text == "Not active") {
            commHeader.color = white;
        }
        else if (commActive.text == "Active") {
            commHeader.color = commColor;
        }
    }
}
