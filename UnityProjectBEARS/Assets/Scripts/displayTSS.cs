using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

[Serializable]
public class RootObject
{
    public Telemetry telemetry; //TELEMETRY.json
    public Telemetry eva; //EVA.json
    public Telemetry comm; //COMM.json
    public Telemetry dcu; //DCU.json
    public Telemetry error; //ERROR.json
    public Telemetry imu; //IMU.json
    public Telemetry rover; //ROVER.json
    public Telemetry spec; //SPEC.json
    public Telemetry uia; //UIA.json
}

[Serializable]
public class Telemetry
{
    //TELEMETRY.json
    public int eva_time;

    //TELEMETRY.json, DCU.json, IMU.json, SPEC.json
    public EvaData eva1;
    public EvaData eva2;

    //EVA.json
    public bool started;
    public bool paused;
    public bool completed;
    public int total_time;
    public EvaData uia;
    public EvaData dcu;
    public EvaData rover;
    public EvaData spec;

    //COMM.json
    public bool comm_tower;

    //ERROR.json
    public bool fan_error;
    public bool oxy_error;
    public bool pump_error;

    //ROVER.json
    public bool posx;
    public bool posy;
    public int qr_id;

    //UIA.json
    public bool eva1_power;
    public bool eva1_oxy;
    public bool eva1_water_supply;
    public bool eva1_water_waste;
    public bool eva2_power;
    public bool eva2_oxy;
    public bool eva2_water_supply;
    public bool eva2_water_waste;
    public bool oxy_vent;
    public bool depress;
}

[Serializable]
public class EvaData
{
    //TELEMETRY.json
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

    //EVA.json
    public bool started;
    public bool completed;
    public float time;

    //DCU.json
    public bool batt;
    public bool oxy;
    public bool comm;
    public bool fan;
    public bool pump;
    public bool co2;

    //IMU.json
    public float posx;
    public float posy;
    public float heading;

    //SPEC.json w/o "id"
    public string name;
    public Comps data;
}

[Serializable]
public class Comps
{
    //SPEC.json
    public float Si02;
    public float Ti02;
    public float Al203;
    public float Fe0;
    public float Mn0;
    public float Mg0;
    public float Ca0;
    public float K20;
    public float P203;
    public float other;
}


public class displayTSS : MonoBehaviour
{
    //TELEMETRY.json
    public TMP_Text timeText1;
    public TMP_Text suitText1;
    public TMP_Text oxyText1;
    public TMP_Text fanText1;
    public TMP_Text timeText2;
    public TMP_Text suitText2;
    public TMP_Text oxyText2;
    public TMP_Text fanText2;

    //EVA.json
    public TMP_Text evaText;
    public TMP_Text evaStatus;
    public TMP_Text evaTotal;

    //COMM.json
    public TMP_Text towerText;

    //DCU.json
    public TMP_Text dcuText1;
    public TMP_Text dcuText2;

    //ERROR.json
    public TMP_Text errorText;

    //IMU.json
    public TMP_Text imuText1;
    public TMP_Text imuText2;

    //ROVER.json
    public TMP_Text roverText;

    //SPEC.json
    public TMP_Text geoText1;
    public TMP_Text geoText2;

    //UIA.json
    public TMP_Text uiaText1;
    //public TMP_Text uiaText2;


    //file paths
    public float updateInterval = 1f; // Update every second
    private string filePathTELEMETRY = "/home/space/TSS_2024/public/json_data/teams/10/TELEMETRY.json";
    private string filePathEVA = "/home/space/TSS_2024/public/json_data/teams/10/EVA.json"; //later add custom variable for 0-10 to set unique team-combo scenarios
    private string filePathCOMM = "/home/space/TSS_2024/public/json_data/COMM.json";
    private string filePathDCU = "/home/space/TSS_2024/public/json_data/DCU.json";
    private string filePathERROR = "/home/space/TSS_2024/public/json_data/ERROR.json";
    private string filePathIMU = "/home/space/TSS_2024/public/json_data/IMU.json";
    private string filePathROVER = "/home/space/TSS_2024/public/json_data/ROVER.json";
    private string filePathSPEC = "/home/space/TSS_2024/public/json_data/SPEC.json";
    private string filePathUIA = "/home/space/TSS_2024/public/json_data/UIA.json";


    //yet to update lines below this point
    void Start()
    {
        if (!File.Exists(filePathTELEMETRY))
        {
            Debug.LogError("JSON file does not exist: " + filePathTELEMETRY);
            return;
        }
        else if (!File.Exists(filePathEVA))
        {
            Debug.LogError("JSON file does not exist: " + filePathEVA);
            return;
        }
        else if (!File.Exists(filePathCOMM))
        {
            Debug.LogError("JSON file does not exist: " + filePathCOMM);
            return;
        }
        else if (!File.Exists(filePathDCU))
        {
            Debug.LogError("JSON file does not exist: " + filePathDCU);
            return;
        }
        else if (!File.Exists(filePathERROR))
        {
            Debug.LogError("JSON file does not exist: " + filePathERROR);
            return;
        }
        else if (!File.Exists(filePathIMU))
        {
            Debug.LogError("JSON file does not exist: " + filePathIMU);
            return;
        }
        else if (!File.Exists(filePathROVER))
        {
            Debug.LogError("JSON file does not exist: " + filePathROVER);
            return;
        }
        else if (!File.Exists(filePathSPEC))
        {
            Debug.LogError("JSON file does not exist: " + filePathSPEC);
            return;
        }
        else if (!File.Exists(filePathUIA))
        {
            Debug.LogError("JSON file does not exist: " + filePathUIA);
            return;
        }
        else
        {
            Debug.Log("All files located");
            StartCoroutine(UpdateTSSUI());
        }

        //StartCoroutine(UpdateTelemetry());
    }

    IEnumerator UpdateTSSUI()
    {
        while (true)
        {
            //string json = File.ReadAllText(filePathTELEMETRY);
            //RootObject rootObject = JsonUtility.FromJson<RootObject>(json);
            //UpdateUI(rootObject.telemetry);
            //yield return new WaitForSeconds(updateInterval);

            string jsonTELE = File.ReadAllText(filePathTELEMETRY);
            RootObject teleObject = JsonUtility.FromJson<RootObject>(jsonTELE);
            UpdateTelemetryUI(teleObject.telemetry);

            string jsonEVA = File.ReadAllText(filePathEVA);
            RootObject evaObject = JsonUtility.FromJson<RootObject>(jsonEVA);
            UpdateEvaUI(evaObject.eva);

            string jsonCOMM = File.ReadAllText(filePathCOMM);
            RootObject commObject = JsonUtility.FromJson<RootObject>(jsonCOMM);
            UpdateCommUI(commObject.comm);

            string jsonDCU = File.ReadAllText(filePathDCU);
            RootObject dcuObject = JsonUtility.FromJson<RootObject>(jsonDCU);
            UpdateDcuUI(dcuObject.dcu);

            string jsonERROR = File.ReadAllText(filePathERROR);
            RootObject errorObject = JsonUtility.FromJson<RootObject>(jsonERROR);
            UpdateErrorUI(errorObject.error);

            string jsonIMU = File.ReadAllText(filePathIMU);
            RootObject imuObject = JsonUtility.FromJson<RootObject>(jsonIMU);
            UpdateImuUI(imuObject.imu);

            string jsonROVER = File.ReadAllText(filePathROVER);
            RootObject roverObject = JsonUtility.FromJson<RootObject>(jsonROVER);
            UpdateRoverUI(roverObject.rover);

            string jsonSPEC = File.ReadAllText(filePathSPEC);
            RootObject specObject = JsonUtility.FromJson<RootObject>(jsonSPEC);
            UpdateSpecUI(specObject.spec);

            string jsonUIA = File.ReadAllText(filePathUIA);
            RootObject uiaObject = JsonUtility.FromJson<RootObject>(jsonUIA);
            UpdateUiaUI(uiaObject.uia);

            yield return new WaitForSeconds(updateInterval);
        }
    }

    void UpdateTelemetryUI(Telemetry telemetry)
    {
        if (telemetry != null && telemetry.eva1 != null)
        {
            timeText1.text = $"EVA Time\t\t\t {telemetry.eva_time} seconds\n" + //reminder to relocate
                        $"Battery Time Left\t\t {telemetry.eva1.batt_time_left} seconds\n" +
                        $"Oxygen Time Left\t\t {telemetry.eva1.oxy_time_left} seconds\n" +
                        $"Heart Rate\t\t\t {telemetry.eva1.heart_rate} bpm";

            suitText1.text = $"Suit O2 Pressure\t\t {telemetry.eva1.suit_pressure_oxy} psi\n" +
                        $"Suit CO2 Pressure\t {telemetry.eva1.suit_pressure_co2} psi\n" +
                        $"Suit Other Pressure\t {telemetry.eva1.suit_pressure_other} psi\n" +
                        $"Suit Total Pressure\t {telemetry.eva1.suit_pressure_total} psi\n" +
                        $"Helmet CO2 Pressure\t {telemetry.eva1.helmet_pressure_co2} psi\n" +
                        $"Scrubber A Pressure\t {telemetry.eva1.scrubber_a_co2_storage} psi\n" +
                        $"Scrubber B Pressure\t {telemetry.eva1.scrubber_b_co2_storage} psi\n" +
                        $"CO2 Production\t\t {telemetry.eva1.co2_production} psi/min";

            oxyText1.text = $"Primary O2 Storage\t {telemetry.eva1.oxy_pri_storage} %\n" +
                       $"Secondary O2 Storage\t {telemetry.eva1.oxy_sec_storage} %\n" +
                       $"Primary O2 Pressure\t {telemetry.eva1.oxy_pri_pressure} psi\n" +
                       $"Secondary O2 Pressure\t {telemetry.eva1.oxy_sec_pressure} psi\n" +
                       $"O2 Consumption\t\t {telemetry.eva1.oxy_consumption} psi/min";

            fanText1.text = $"Primary Fan\t\t {telemetry.eva1.fan_pri_rpm} rpm\n" +
                       $"Secondary Fan\t\t {telemetry.eva1.fan_sec_rpm} rpm\n" +
                       $"Temperature\t\t {telemetry.eva1.temperature} °F\n" +
                       $"Coolant\t\t\t {telemetry.eva1.coolant_ml} ml\n" +
                       $"H2O Gas Pressure\t {telemetry.eva1.coolant_gas_pressure} psi\n" +
                       $"H2O Liquid Pressure\t {telemetry.eva1.coolant_liquid_pressure} psi";
        }

        if (telemetry != null && telemetry.eva2 != null)
        {
            timeText2.text = $"EVA Time\t\t\t {telemetry.eva_time} seconds\n" + //reminder to relocate
                        $"Battery Time Left\t\t {telemetry.eva2.batt_time_left} seconds\n" +
                        $"Oxygen Time Left\t\t {telemetry.eva2.oxy_time_left} seconds\n" +
                        $"Heart Rate\t\t\t {telemetry.eva2.heart_rate} bpm";

            suitText2.text = $"Suit O2 Pressure\t\t {telemetry.eva2.suit_pressure_oxy} psi\n" +
                        $"Suit CO2 Pressure\t {telemetry.eva2.suit_pressure_co2} psi\n" +
                        $"Suit Other Pressure\t {telemetry.eva2.suit_pressure_other} psi\n" +
                        $"Suit Total Pressure\t {telemetry.eva2.suit_pressure_total} psi\n" +
                        $"Helmet CO2 Pressure\t {telemetry.eva2.helmet_pressure_co2} psi\n" +
                        $"Scrubber A Pressure\t {telemetry.eva2.scrubber_a_co2_storage} psi\n" +
                        $"Scrubber B Pressure\t {telemetry.eva2.scrubber_b_co2_storage} psi\n" +
                        $"CO2 Production\t\t {telemetry.eva2.co2_production} psi/min";

            oxyText2.text = $"Primary O2 Storage\t {telemetry.eva2.oxy_pri_storage} %\n" +
                       $"Secondary O2 Storage\t {telemetry.eva2.oxy_sec_storage} %\n" +
                       $"Primary O2 Pressure\t {telemetry.eva2.oxy_pri_pressure} psi\n" +
                       $"Secondary O2 Pressure\t {telemetry.eva2.oxy_sec_pressure} psi\n" +
                       $"O2 Consumption\t\t {telemetry.eva2.oxy_consumption} psi/min";

            fanText2.text = $"Primary Fan\t\t {telemetry.eva2.fan_pri_rpm} rpm\n" +
                       $"Secondary Fan\t\t {telemetry.eva2.fan_sec_rpm} rpm\n" +
                       $"Temperature\t\t {telemetry.eva2.temperature} °F\n" +
                       $"Coolant\t\t\t {telemetry.eva2.coolant_ml} ml\n" +
                       $"H2O Gas Pressure\t {telemetry.eva2.coolant_gas_pressure} psi\n" +
                       $"H2O Liquid Pressure\t {telemetry.eva2.coolant_liquid_pressure} psi";
        }
    }

    void UpdateEvaUI(Telemetry eva)
    {
        if (eva != null)
        {
            if (eva.started == true)
            {
                evaStatus.text = $"EVA Status:\t\t Ongoing";
            }
            else if (eva.paused == true)
            {
                evaStatus.text = $"EVA Status:\t\t Paused";
            }
            else
            {
                evaStatus.text = $"EVA Status:\t\t Completed";
            }
            
            evaTotal.text = $"EVA Alloted Time:\t {eva.total_time} seconds";
            
            //evaText.text = $"EVA Status\t\t\t {eva.eva_time} seconds\n" +
            //            $"Battery Time Left\t\t {telemetry.eva1.batt_time_left} seconds\n" +
            //            $"Oxygen Time Left\t\t {telemetry.eva1.oxy_time_left} seconds\n" +
            //            $"Heart Rate\t\t\t {telemetry.eva1.heart_rate} bpm";
        }
    }

    void UpdateCommUI(Telemetry comm)
    {
        if (comm != null)
        {
            towerText.text = $"comm test:\t {comm.comm_tower} units";
        }
    }

    void UpdateDcuUI(Telemetry dcu)
    {
        if (dcu != null && dcu.eva1 != null)
        {
            dcuText1.text = $"dcu1 test:\t {dcu.eva1.batt} units";
        }

        if (dcu != null && dcu.eva2 != null)
        {
            dcuText2.text = $"dcu2 test:\t {dcu.eva2.batt} units";
        }
    }

    void UpdateErrorUI(Telemetry error)
    {
        if (error != null)
        {
            errorText.text = $"error test:\t {error.fan_error} units";
        }
    }

    void UpdateImuUI(Telemetry imu)
    {
        if (imu != null && imu.eva1 != null)
        {
            imuText1.text = $"imu test1:\t {imu.eva1.posx} units";
        }

        if (imu != null && imu.eva2 != null)
        {
            imuText2.text = $"imu test2:\t {imu.eva2.posx} units";
        }
    }

    void UpdateRoverUI(Telemetry rover)
    {
        if (rover != null)
        {
            roverText.text = $"rover test:\t {rover.posx} units";
        }
    }

    void UpdateSpecUI(Telemetry spec)
    {
        if (spec != null && spec.eva1 != null)
        {
            geoText1.text = $"spec test1:\t {spec.eva1.data.Si02} units";
        }

        if (spec != null && spec.eva2 != null)
        {
            geoText2.text = $"spec test2:\t {spec.eva2.data.Si02} units";
        }
    }

    void UpdateUiaUI(Telemetry uia)
    {
        if (uia != null)
        {
            uiaText1.text = $"uia test:\t {uia.eva1_power} units";
        }
    }

}
