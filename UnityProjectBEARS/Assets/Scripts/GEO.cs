using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GEO : MonoBehaviour
{
    // rock data are dummy variables until TSS
    public GameObject geoUI;
    public int rockSerial;
    public float rockData1;
    public float rockData2;

    // Start is called before the first frame update
    void Start()
    {

    }

    //public void initialVarSet(int xrfSerial, float xrfData1, float xrfData2):
        //grab data that XRF sends from rock scan
        //rockSerial = xrfSerial;
        //rockData1 = xrfData1;
        //rockData2 = xrfData2;
        //initialize the placeholder variables with this data, for each scan made
        //send alert to DE that scan was a success

    //public void getGeoRange() :
        //compare placeholder variables to their respective data ranges through the TSS
        //if there is a 100% match, return that rock type

    //public void displayMatch() :
	    //return data as output for their respective gameobject textfield

    //public void switchCheck() :
	    //check input of left or right
	    //if no scan exist in that respective direction, return error message
	    //else, change scan data displayed in that direction

    // Update is called once per frame
    void Update()
    {

    }
}
