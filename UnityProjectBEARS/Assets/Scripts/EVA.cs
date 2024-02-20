using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EVA : MonoBehaviour
{
    // Dummy Variables and Lists
    public GameObject evaUi;
    bool completedTask;
    bool completedObjective;
    public int taskData;
    string inputTasks;
    string inputObjective;

    // List for EVA Objectives to be sent from LMCC
    List<string> evaObjectives = new List<string>();
    // List of Tasks for the particular EVA Objective
    List<string> objectiveTasks = new List<string>();
    
    public void getObjective()
    {
    
    }

    public void getTasks()
    {

    }

    public void statusCheckTask()
    {
        
    }

    public void statusCheckObjective() 
    {
    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
