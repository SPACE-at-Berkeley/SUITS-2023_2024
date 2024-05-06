using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

[Serializable]
public class RootObject
{
    public Telemetry telemetry;
}

[Serializable]
public class Telemetry
{
    public int eva_time;
    public EvaData eva1;
    public EvaData eva2;
}

[Serializable]
public class EvaData
{
    public float batt_time_left;
    public float oxy_time_left;
    public float heart_rate;
    
    public float suit_pressure_oxy;
    public float suit_pressure_co2;
    public float suit_pressure_other;
    public float suit_pressure_total;
    public float helmet_pressure_co2;
    public float scrubber_a_co2_storage;
    public float scrubber_b_co2_storage;
    public float co2_production;
    
    public float oxy_pri_storage;
    public float oxy_sec_storage;
    public float oxy_pri_pressure;
    public float oxy_sec_pressure;
    public float oxy_consumption;
    
    public float fan_pri_rpm;
    public float fan_sec_rpm;
    public float temperature;
    public float coolant_ml;
    public float coolant_gas_pressure;
    public float coolant_liquid_pressure;
}

public class displayTSS : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text suitText;
    public TMP_Text oxyText;
    public TMP_Text fanText;

    public float updateInterval = 2f; // Update every 2 seconds.
    private string filePath = "/home/space/TSS_2024/public/json_data/teams/10/TELEMETRY.json";

    void Start()
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError("JSON file does not exist: " + filePath);
            return;
        }

        StartCoroutine(UpdateTelemetry());
    }

    IEnumerator UpdateTelemetry()
    {
        while (true)
        {
            string json = File.ReadAllText(filePath);
            RootObject rootObject = JsonUtility.FromJson<RootObject>(json);
            UpdateUI(rootObject.telemetry);
            yield return new WaitForSeconds(updateInterval);
        }
    }

    void UpdateUI(Telemetry telemetry)
    {
        if (telemetry != null && telemetry.eva1 != null)
        {
            timeText.text = $"EVA Time\t\t\t {telemetry.eva_time} seconds\n" +
            		    $"Battery Time Left\t\t {telemetry.eva1.batt_time_left} seconds\n" +
            		    $"Oxygen Time Left\t\t {telemetry.eva1.oxy_time_left} seconds\n" +
            		    $"Heart Rate\t\t\t {telemetry.eva1.heart_rate} bpm";
            		    
            suitText.text = $"Suit O2 Pressure\t\t {telemetry.eva1.suit_pressure_oxy} psi\n" +
            		    $"Suit CO2 Pressure\t {telemetry.eva1.suit_pressure_co2} psi\n" +
            		    $"Suit Other Pressure\t {telemetry.eva1.suit_pressure_other} psi\n" +
            		    $"Suit Total Pressure\t {telemetry.eva1.suit_pressure_total} psi\n" +
            		    $"Helmet CO2 Pressure\t {telemetry.eva1.helmet_pressure_co2} psi\n" +
            		    $"Scrubber A Pressure\t {telemetry.eva1.scrubber_a_co2_storage} psi\n" +
            		    $"Scrubber B Pressure\t {telemetry.eva1.scrubber_b_co2_storage} psi\n" +
            		    $"CO2 Production\t\t {telemetry.eva1.co2_production} psi/min";
            		    
            oxyText.text = $"Primary O2 Storage\t {telemetry.eva1.oxy_pri_storage} %\n" +
            		   $"Secondary O2 Storage\t {telemetry.eva1.oxy_sec_storage} %\n" +
            		   $"Primary O2 Pressure\t {telemetry.eva1.oxy_pri_pressure} psi\n" +
            		   $"Secondary O2 Pressure\t {telemetry.eva1.oxy_sec_pressure} psi\n" +
            		   $"O2 Consumption\t\t {telemetry.eva1.oxy_consumption} psi/min";
            		   
            fanText.text = $"Primary Fan\t\t {telemetry.eva1.fan_pri_rpm} rpm\n" +
            		   $"Secondary Fan\t\t {telemetry.eva1.fan_sec_rpm} rpm\n" +
            		   $"Temperature\t\t {telemetry.eva1.temperature} °F\n" +
            		   $"Coolant\t\t\t {telemetry.eva1.coolant_ml} ml\n" +
            		   $"H2O Gas Pressure\t {telemetry.eva1.coolant_gas_pressure} psi\n" +
            		   $"H2O Liquid Pressure\t {telemetry.eva1.coolant_liquid_pressure} psi";
        }
    }
} 
