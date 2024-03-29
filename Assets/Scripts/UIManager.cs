using UnityEngine;
using TMPro; // Include the TextMeshPro namespace
using UnityEngine.UI;
using System.Collections.Generic;


public class UIManager : MonoBehaviour
{
    [System.Serializable]
    public class SuitPanel
    {
        public TextMeshProUGUI evaTimeText; // Only used for "My Suit" panel
        public TextMeshProUGUI batteryText;
        public TextMeshProUGUI oxygenText;
        public TextMeshProUGUI waterText;
        // Other UI elements can be added as needed
    }


    [System.Serializable]
    public class PartnerSuitPanel
    {
        // Omit the EVA Time for the partner suit
        public TextMeshProUGUI batteryText;
        public TextMeshProUGUI oxygenText;
        public TextMeshProUGUI waterText;
        // Other UI elements can be added as needed
    }


    [System.Serializable]
    public class TaskPanel
    {
        public List<Button> taskButtons;
        public TextMeshProUGUI egressText;
    }


    public SuitPanel mySuitPanel;
    public PartnerSuitPanel partnerSuitPanel;
    public TaskPanel evaTaskPanel;


    void Start()
    {
        // Initialize UI elements with default values or values from a data source
        UpdateMySuitPanel("04:33:34", "4hrs", "2hrs", "3hrs");
        UpdatePartnerSuitPanel("3hrs", "2hrs", "3hrs");
        UpdateTaskPanel(new List<int> { 1, 2, 3, 4, 5, 6 }, "3/17 done");
    }


    public void UpdateMySuitPanel(string evaTime, string battery, string oxygen, string water)
    {
        mySuitPanel.evaTimeText.text = evaTime;
        mySuitPanel.batteryText.text = battery;
        mySuitPanel.oxygenText.text = oxygen;
        mySuitPanel.waterText.text = water;
    }


    public void UpdatePartnerSuitPanel(string battery, string oxygen, string water)
    {
        partnerSuitPanel.batteryText.text = battery;
        partnerSuitPanel.oxygenText.text = oxygen;
        partnerSuitPanel.waterText.text = water;
    }


    public void UpdateTaskPanel(List<int> tasks, string egress)
    {
//         for (int i = 0; i < evaTaskPanel.taskButtons.Count; i++)
//         {
//             if (i < tasks.Count)
//             {
//                 evaTaskPanel.taskButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = tasks[i].ToString();
//                 evaTaskPanel.taskButtons[i].gameObject.SetActive(true);
//             }
//             else
//             {
//                 evaTaskPanel.taskButtons[i].gameObject.SetActive(false);
//             }
//         }


//         evaTaskPanel.egressText.text = egress;
    }

}

