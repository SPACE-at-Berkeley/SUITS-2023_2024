using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSwitcher : MonoBehaviour
{
    public List<GameObject> procedures; // List to hold your text objects
    private int currentIndex = 0; // Current text index

    void Start()
    {
        UpdateTextVisibility(); // Initial call to set up text visibility
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeText(1); // Move right in the list
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeText(-1); // Move left in the list
        }
    }

    void ChangeText(int direction)
    {
        procedures[currentIndex].gameObject.SetActive(false); // Hide current text
        currentIndex += direction; // Change index
        // Loop around the list
        if (currentIndex >= procedures.Count) currentIndex = 0;
        else if (currentIndex < 0) currentIndex = procedures.Count - 1;

        UpdateTextVisibility(); // Update text visibility based on new index
    }

    void UpdateTextVisibility()
    {
        procedures[currentIndex].gameObject.SetActive(true); // Show new current text
    }
}
