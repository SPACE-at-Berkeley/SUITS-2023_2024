using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
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
    //public int qr_id;

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
    public float SiO2;
    public float TiO2;
    public float Al2O3;
    public float FeO;
    public float MnO;
    public float MgO;
    public float CaO;
    public float K2O;
    public float P2O3;
    public float other;
}


public class displayReTSS : MonoBehaviour
{
    //TELEMETRY.json
    public TMP_Text timeText;

    //ev-1
    public TMP_Text heartRateText1;
    public TMP_Text temperatureText1;
    public TMP_Text battTimeText1;
    public TMP_Text oxyTimeText1;
    public TMP_Text oxyConsumptionText1;
    public TMP_Text co2ProductionText1;

    public TMP_Text suitOxyText1;
    public TMP_Text suitCo2Text1;
    public TMP_Text suitOtherText1;
    public TMP_Text suitTotalText1;
    public TMP_Text helmetCo2Text1;
    public TMP_Text scrubberAText1;
    public TMP_Text scrubberBText1;

    public TMP_Text priOxyStorageText1;
    public GameObject priOxyStorLR1;
    public GameObject priOxyStorG1;
    public GameObject priOxyStorRR1;
    public TMP_Text secOxyStorageText1;
    public GameObject secOxyStorLR1;
    public GameObject secOxyStorG1;
    public GameObject secOxyStorRR1;
    public TMP_Text priOxyPressureText1;
    public GameObject priOxyPresLR1;
    public GameObject priOxyPresG1;
    public GameObject priOxyPresRR1;
    public TMP_Text secOxyPressureText1;
    public GameObject secOxyPresLR1;
    public GameObject secOxyPresG1;
    public GameObject secOxyPresRR1;

    public TMP_Text coolantGasPressureText1;
    public GameObject gasPresLR1;
    public GameObject gasPresG1;
    public GameObject gasPresRR1;
    public TMP_Text coolantLiquidPressureText1;
    public GameObject liqPresLR1;
    public GameObject liqPresG1;
    public GameObject liqPresRR1;

    public TMP_Text priFanText1;
    public TMP_Text secFanText1;
    public TMP_Text coolantText1;

    //ev-2
    public TMP_Text heartRateText2;
    public TMP_Text temperatureText2;
    public TMP_Text battTimeText2;
    public TMP_Text oxyTimeText2;
    public TMP_Text oxyConsumptionText2;
    public TMP_Text co2ProductionText2;

    public TMP_Text suitOxyText2;
    public TMP_Text suitCo2Text2;
    public TMP_Text suitOtherText2;
    public TMP_Text suitTotalText2;
    public TMP_Text helmetCo2Text2;
    public TMP_Text scrubberAText2;
    public TMP_Text scrubberBText2;

    public TMP_Text priOxyStorageText2;
    public GameObject priOxyStorLR2;
    public GameObject priOxyStorG2;
    public GameObject priOxyStorRR2;
    public TMP_Text secOxyStorageText2;
    public GameObject secOxyStorLR2;
    public GameObject secOxyStorG2;
    public GameObject secOxyStorRR2;
    public TMP_Text priOxyPressureText2;
    public GameObject priOxyPresLR2;
    public GameObject priOxyPresG2;
    public GameObject priOxyPresRR2;
    public TMP_Text secOxyPressureText2;
    public GameObject secOxyPresLR2;
    public GameObject secOxyPresG2;
    public GameObject secOxyPresRR2;

    public TMP_Text coolantGasPressureText2;
    public GameObject gasPresLR2;
    public GameObject gasPresG2;
    public GameObject gasPresRR2;
    public TMP_Text coolantLiquidPressureText2;
    public GameObject liqPresLR2;
    public GameObject liqPresG2;
    public GameObject liqPresRR2;

    public TMP_Text priFanText2;
    public TMP_Text secFanText2;
    public TMP_Text coolantText2;



    //EVA.json
    //public TMP_Text evaText;
    public TMP_Text evaStatus;
    public TMP_Text evaStatusUIA;
    public TMP_Text evaStatusDCU;
    public TMP_Text evaStatusGEO;
    public TMP_Text evaStatusROVER;

    //COMM.json
    public TMP_Text towerText;

    //DCU.json
    //public TMP_Text dcuText1;
    //public TMP_Text dcuText2;
    public TMP_Text dcuBatt2;
    public TMP_Text dcuFan2;
    public TMP_Text dcuPump2;
    public TMP_Text dcuCo2;
    public TMP_Text dcuOxy2;
    public TMP_Text dcuComm2;

    //EVA1
    public TMP_Text dcuBatt1;
    public TMP_Text dcuFan1;
    public TMP_Text dcuPump1;
    public TMP_Text dcuCo2_1;
    public TMP_Text dcuOxy1;
    public TMP_Text dcuComm1;

    //ERROR.json
    public TMP_Text errorText;

    //IMU.json
    public TMP_Text imuText1;
    public TMP_Text imuText2;

    //ROVER.json
    public TMP_Text roverText;


    //SPEC.json
    //public TMP_Text geoText1;
    public TMP_Text typeBasalt1;
    public TMP_Text siText1;
    public TMP_Text tiText1;
    public TMP_Text alText1;
    public TMP_Text feText1;
    public TMP_Text mnText1;
    public TMP_Text mgText1;
    public TMP_Text caText1;
    public TMP_Text kText1;
    public TMP_Text pText1;
    public TMP_Text otherText1;
    //public TMP_Text geoText2;
    public TMP_Text typeBasalt2;
    public TMP_Text siText2;
    public TMP_Text tiText2;
    public TMP_Text alText2;
    public TMP_Text feText2;
    public TMP_Text mnText2;
    public TMP_Text mgText2;
    public TMP_Text caText2;
    public TMP_Text kText2;
    public TMP_Text pText2;
    public TMP_Text otherText2;


    //UIA.json
    //public TMP_Text uiaText1;
    public Slider supplyFlip1;
    public Slider wasteFlip1;
    public Slider powerFlip1;
    public Slider oxygenFlip1;
    //public TMP_Text uiaText2;
    public Slider supplyFlip2;
    public Slider wasteFlip2;
    public Slider powerFlip2;
    public Slider oxygenFlip2;
    //public TMP_Text uiaSide;
    public Slider ventFlip;
    public Slider depressFlip;


    //file paths
    public float updateInterval = 1f; // Update every second
    //LMCC Laptop path: /home/space/TSS_2024/public/json_data/
    private string filePathTELEMETRY = "c/Users/gonza/myUnityProjects/TSS/TSS_2024/public/json_data/teams/10/TELEMETRY.json";
    private string filePathEVA = "c/Users/gonza/myUnityProjects/TSS/TSS_2024/public/json_data/teams/10/EVA.json"; //later add custom variable for 0-10 to set unique team-combo scenarios
    private string filePathCOMM = "c/Users/gonza/myUnityProjects/TSS/TSS_2024/public/json_data/COMM.json";
    private string filePathDCU = "c/Users/gonza/myUnityProjects/TSS/TSS_2024/public/json_data/DCU.json";
    private string filePathERROR = "c/Users/gonza/myUnityProjects/TSS/TSS_2024/public/json_data/ERROR.json";
    private string filePathIMU = "c/Users/gonza/myUnityProjects/TSS/TSS_2024/public/json_data/IMU.json";
    private string filePathROVER = "c/Users/gonza/myUnityProjects/TSS/TSS_2024/public/json_data/ROVER.json";
    private string filePathSPEC = "c/Users/gonza/myUnityProjects/TSS/TSS_2024/public/json_data/SPEC.json";
    private string filePathUIA = "c/Users/gonza/myUnityProjects/TSS/TSS_2024/public/json_data/UIA.json";


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
        if (telemetry != null)
        {
            TimeSpan evaTimeSpan = TimeSpan.FromSeconds(telemetry.eva_time);
            string formattedEvaTime = string.Format("{0:D2}:{1:D2}:{2:D2}", evaTimeSpan.Hours, evaTimeSpan.Minutes, evaTimeSpan.Seconds);
            timeText.text = $"EVA Time\n{formattedEvaTime}";
        }

        if (telemetry != null && telemetry.eva1 != null)
        {
            if (telemetry.eva1.oxy_pri_storage < 20)
            {
                priOxyStorLR1.SetActive(true);
                priOxyStorG1.SetActive(false);
                priOxyStorRR1.SetActive(false);
            } 
            else if (telemetry.eva1.oxy_pri_storage > 100)
            {
                priOxyStorLR1.SetActive(false);
                priOxyStorG1.SetActive(false);
                priOxyStorRR1.SetActive(true);
            }
            else
            {
                priOxyStorLR1.SetActive(false);
                priOxyStorG1.SetActive(true);
                priOxyStorRR1.SetActive(false);
            }

            if (telemetry.eva1.oxy_sec_storage < 20)
            {
                secOxyStorLR1.SetActive(true);
                secOxyStorG1.SetActive(false);
                secOxyStorRR1.SetActive(false);
            } 
            else if (telemetry.eva1.oxy_sec_storage > 100)
            {
                secOxyStorLR1.SetActive(false);
                secOxyStorG1.SetActive(false);
                secOxyStorRR1.SetActive(true);
            }
            else
            {
                secOxyStorLR1.SetActive(false);
                secOxyStorG1.SetActive(true);
                secOxyStorRR1.SetActive(false);
            }
            
            if (telemetry.eva1.oxy_pri_pressure < 600)
            {
                priOxyPresLR1.SetActive(true);
                priOxyPresG1.SetActive(false);
                priOxyPresRR1.SetActive(false);
            } 
            else if (telemetry.eva1.oxy_pri_pressure > 3000)
            {
                priOxyPresLR1.SetActive(false);
                priOxyPresG1.SetActive(false);
                priOxyPresRR1.SetActive(true);
            }
            else
            {
                priOxyPresLR1.SetActive(false);
                priOxyPresG1.SetActive(true);
                priOxyPresRR1.SetActive(false);
            }
            
            if (telemetry.eva1.oxy_sec_pressure < 600)
            {
                secOxyPresLR1.SetActive(true);
                secOxyPresG1.SetActive(false);
                secOxyPresRR1.SetActive(false);
            } 
            else if (telemetry.eva1.oxy_sec_pressure > 3000)
            {
                secOxyPresLR1.SetActive(false);
                secOxyPresG1.SetActive(false);
                secOxyPresRR1.SetActive(true);
            }
            else
            {
                secOxyPresLR1.SetActive(false);
                secOxyPresG1.SetActive(true);
                secOxyPresRR1.SetActive(false);
            }
            
            if (telemetry.eva1.coolant_liquid_pressure < 100)
            {
                liqPresLR1.SetActive(true);
                liqPresG1.SetActive(false);
                liqPresRR1.SetActive(false);
            } 
            else if (telemetry.eva1.coolant_liquid_pressure > 700)
            {
                liqPresLR1.SetActive(false);
                liqPresG1.SetActive(false);
                liqPresRR1.SetActive(true);
            }
            else
            {
                liqPresLR1.SetActive(false);
                liqPresG1.SetActive(true);
                liqPresRR1.SetActive(false);
            }
            
            if (telemetry.eva1.coolant_gas_pressure < 0)
            {
                gasPresLR1.SetActive(true);
                gasPresG1.SetActive(false);
                gasPresRR1.SetActive(false);
            } 
            else if (telemetry.eva1.coolant_gas_pressure > 700)
            {
                gasPresLR1.SetActive(false);
                gasPresG1.SetActive(false);
                gasPresRR1.SetActive(true);
            }
            else
            {
                gasPresLR1.SetActive(false);
                gasPresG1.SetActive(true);
                gasPresRR1.SetActive(false);
            }
            
            if (telemetry.eva2.oxy_pri_storage < 20)
            {
                priOxyStorLR2.SetActive(true);
                priOxyStorG2.SetActive(false);
                priOxyStorRR2.SetActive(false);
            } 
            else if (telemetry.eva2.oxy_pri_storage > 100)
            {
                priOxyStorLR2.SetActive(false);
                priOxyStorG2.SetActive(false);
                priOxyStorRR2.SetActive(true);
            }
            else
            {
                priOxyStorLR2.SetActive(false);
                priOxyStorG2.SetActive(true);
                priOxyStorRR2.SetActive(false);
            }
            
            if (telemetry.eva2.oxy_sec_storage < 20)
            {
                secOxyStorLR2.SetActive(true);
                secOxyStorG2.SetActive(false);
                secOxyStorRR2.SetActive(false);
            } 
            else if (telemetry.eva2.oxy_sec_storage > 100)
            {
                secOxyStorLR2.SetActive(false);
                secOxyStorG2.SetActive(false);
                secOxyStorRR2.SetActive(true);
            }
            else
            {
                secOxyStorLR2.SetActive(false);
                secOxyStorG2.SetActive(true);
                secOxyStorRR2.SetActive(false);
            }
            
            if (telemetry.eva2.oxy_pri_pressure < 600)
            {
                priOxyPresLR2.SetActive(true);
                priOxyPresG2.SetActive(false);
                priOxyPresRR2.SetActive(false);
            } 
            else if (telemetry.eva2.oxy_pri_pressure > 3000)
            {
                priOxyPresLR2.SetActive(false);
                priOxyPresG2.SetActive(false);
                priOxyPresRR2.SetActive(true);
            }
            else
            {
                priOxyPresLR2.SetActive(false);
                priOxyPresG2.SetActive(true);
                priOxyPresRR2.SetActive(false);
            }
            
            if (telemetry.eva2.oxy_sec_pressure < 600)
            {
                secOxyPresLR2.SetActive(true);
                secOxyPresG2.SetActive(false);
                secOxyPresRR2.SetActive(false);
            } 
            else if (telemetry.eva2.oxy_sec_pressure > 3000)
            {
                secOxyPresLR2.SetActive(false);
                secOxyPresG2.SetActive(false);
                secOxyPresRR2.SetActive(true);
            }
            else
            {
                secOxyPresLR2.SetActive(false);
                secOxyPresG2.SetActive(true);
                secOxyPresRR2.SetActive(false);
            }
            
            if (telemetry.eva2.coolant_liquid_pressure < 100)
            {
                liqPresLR2.SetActive(true);
                liqPresG2.SetActive(false);
                liqPresRR2.SetActive(false);
            }
            else if (telemetry.eva2.coolant_liquid_pressure > 700)
            {
                liqPresLR2.SetActive(false);
                liqPresG2.SetActive(false);
                liqPresRR2.SetActive(true);
            }
            else
            {
                liqPresLR2.SetActive(false);
                liqPresG2.SetActive(true);
                liqPresRR2.SetActive(false);
            }
 
            if (telemetry.eva2.coolant_gas_pressure < 0)
            {
                gasPresLR2.SetActive(true);
                gasPresG2.SetActive(false);
                gasPresRR2.SetActive(false);
            } 
            else if (telemetry.eva2.coolant_gas_pressure > 700)
            {
                gasPresLR2.SetActive(false);
                gasPresG2.SetActive(false);
                gasPresRR2.SetActive(true);
            }
            else
            {
                gasPresLR2.SetActive(false);
                gasPresG2.SetActive(true);
                gasPresRR2.SetActive(false);
            }


            heartRateText1.text = $"Heart Rate\n{telemetry.eva1.heart_rate} bpm";
            temperatureText1.text = $"Temperature\n{telemetry.eva1.temperature} �F";
            battTimeText1.text = $"Battery Time Left\n{telemetry.eva1.batt_time_left} seconds";
            oxyTimeText1.text = $"Oxygen Time Left\n{telemetry.eva1.oxy_time_left} seconds";
            co2ProductionText1.text = $"CO2 Production\n{telemetry.eva1.co2_production} psi/min";
            oxyConsumptionText1.text = $"O2 Consumption\n{telemetry.eva1.oxy_consumption} psi/min";

            //suit spot
            suitOxyText1.text = $"Suit O2 Pressure\n{telemetry.eva1.suit_pressure_oxy} psi";
            suitCo2Text1.text = $"Suit CO2 Pressure\n{telemetry.eva1.suit_pressure_co2} psi";
            suitOtherText1.text = $"Suit Other Pressure\n{telemetry.eva1.suit_pressure_other} psi";
            suitTotalText1.text = $"Suit Total Pressure\n{telemetry.eva1.suit_pressure_total} psi";
            helmetCo2Text1.text = $"Helmet CO2 Pressure\n{telemetry.eva1.helmet_pressure_co2} psi";
            scrubberAText1.text = $"Scrubber A Pressure\n{telemetry.eva1.scrubber_a_co2_storage} psi";
            scrubberBText1.text = $"Scrubber B Pressure\n{telemetry.eva1.scrubber_b_co2_storage} psi";

            //oxygen spot
            priOxyStorageText1.text = $"Primary O2 Storage\n{telemetry.eva1.oxy_pri_storage} %";
            secOxyStorageText1.text = $"Secondary O2 Storage\n{telemetry.eva1.oxy_sec_storage} %";
            priOxyPressureText1.text = $"Primary O2 Pressure\n{telemetry.eva1.oxy_pri_pressure} psi";
            secOxyPressureText1.text = $"Secondary O2 Pressure\n{telemetry.eva1.oxy_sec_pressure} psi";

            priFanText1.text = $"Primary Fan\n{telemetry.eva1.fan_pri_rpm} rpm";
            secFanText1.text = $"Secondary Fan\n{telemetry.eva1.fan_sec_rpm} rpm";
            coolantGasPressureText1.text = $"H2O Gas Pressure\n{telemetry.eva1.coolant_gas_pressure} psi";
            coolantLiquidPressureText1.text = $"H2O Liquid Pressure\n{telemetry.eva1.coolant_liquid_pressure} psi";
            coolantText1.text = $"Coolant\n{telemetry.eva1.coolant_ml} ml";
        }

        if (telemetry != null && telemetry.eva2 != null)
        {
            heartRateText2.text = $"Heart Rate\n{telemetry.eva2.heart_rate} bpm";
            temperatureText2.text = $"Temperature\n{telemetry.eva2.temperature} �F";
            battTimeText2.text = $"Battery Time Left\n{telemetry.eva2.batt_time_left} seconds";
            oxyTimeText2.text = $"Oxygen Time Left\n{telemetry.eva2.oxy_time_left} seconds";
            co2ProductionText2.text = $"CO2 Production\n{telemetry.eva2.co2_production} psi/min";
            oxyConsumptionText2.text = $"O2 Consumption\n{telemetry.eva2.oxy_consumption} psi/min";

            suitOxyText2.text = $"Suit O2 Pressure\n{telemetry.eva2.suit_pressure_oxy} psi";
            suitCo2Text2.text = $"Suit CO2 Pressure\n{telemetry.eva2.suit_pressure_co2} psi";
            suitOtherText2.text = $"Suit Other Pressure\n{telemetry.eva2.suit_pressure_other} psi";
            suitTotalText2.text = $"Suit Total Pressure\n{telemetry.eva2.suit_pressure_total} psi";
            helmetCo2Text2.text = $"Helmet CO2 Pressure\n{telemetry.eva2.helmet_pressure_co2} psi";
            scrubberAText2.text = $"Scrubber A Pressure\n{telemetry.eva2.scrubber_a_co2_storage} psi";
            scrubberBText2.text = $"Scrubber B Pressure\n{telemetry.eva2.scrubber_b_co2_storage} psi";

            priOxyStorageText2.text = $"Primary O2 Storage\n{telemetry.eva2.oxy_pri_storage} %";
            secOxyStorageText2.text = $"Secondary O2 Storage\n{telemetry.eva2.oxy_sec_storage} %";
            priOxyPressureText2.text = $"Primary O2 Pressure\n{telemetry.eva2.oxy_pri_pressure} psi";
            secOxyPressureText2.text = $"Secondary O2 Pressure\n{telemetry.eva2.oxy_sec_pressure} psi";

            priFanText2.text = $"Primary Fan\n{telemetry.eva2.fan_pri_rpm} rpm";
            secFanText2.text = $"Secondary Fan\n{telemetry.eva2.fan_sec_rpm} rpm";
            coolantGasPressureText2.text = $"H2O Gas Pressure\n{telemetry.eva2.coolant_gas_pressure} psi";
            coolantLiquidPressureText2.text = $"H2O Liquid Pressure\n{telemetry.eva2.coolant_liquid_pressure} psi";
            coolantText2.text = $"Coolant\n{telemetry.eva2.coolant_ml} ml";
        }
    }

    void UpdateEvaUI(Telemetry eva)
    {
        if (eva != null)
        {
            if (eva.started == true)
            {
                evaStatus.text = $"EVA Mission Status:\t\t Ongoing\n" +
                                $"EVA Mission Time:\t {eva.total_time} seconds";
            }
            else if (eva.paused == true)
            {
                evaStatus.text = $"EVA Mission Status:\t\t Paused\n" +
                                $"EVA Mission Time:\t {eva.total_time} seconds";
            }
            else
            {
                evaStatus.text = $"EVA Mission Status:\t\t Completed\n" +
                                $"EVA Mission Time:\t {eva.total_time} seconds";
            }


            if (eva.uia.completed == true)
            {
                evaStatusUIA.text = $"UIA Task Status:\t\t Completed\n" + //false true    true true
                    $"UIA Task Time:\t {eva.uia.time} seconds";
            }
            else if (eva.uia.started == true)
            {
                evaStatusUIA.text = $"UIA Task Status:\t\t Ongoing\n" + //true false
                    $"UIA Task Time:\t {eva.uia.time} seconds";
            }
            else
            {
                evaStatusUIA.text = $"UIA Task Status:\t\t Not Assigned\n" + //false false
                    $"UIA Task Time:\t {eva.uia.time} seconds";
            }


            if (eva.dcu.completed == true)
            {
                evaStatusDCU.text = $"DCU Task Status:\t\t Completed\n" + //false true    true true
                    $"DCU Task Time:\t {eva.dcu.time} seconds";
            }
            else if (eva.dcu.started == true)
            {
                evaStatusDCU.text = $"DCU Task Status:\t\t Ongoing\n" + //true false
                    $"DCU Task Time:\t {eva.dcu.time} seconds";
            }
            else
            {
                evaStatusDCU.text = $"DCU Task Status:\t\t Not Assigned\n" + //false false
                    $"DCU Task Time:\t {eva.dcu.time} seconds";
            }


            if (eva.rover.completed == true)
            {
                evaStatusROVER.text = $"ROVER Task Status:\t\t Completed\n" + //false true    true true
                    $"ROVER Task Time:\t {eva.rover.time} seconds";
            }
            else if (eva.rover.started == true)
            {
                evaStatusROVER.text = $"ROVER Task Status:\t\t Ongoing\n" + //true false
                    $"ROVER Task Time:\t {eva.rover.time} seconds";
            }
            else
            {
                evaStatusROVER.text = $"ROVER Task Status:\t\t Not Assigned\n" + //false false
                    $"ROVER Task Time:\t {eva.rover.time} seconds";
            }


            if (eva.spec.completed == true)
            {
                evaStatusGEO.text = $"GEO Task Status:\t\t Completed\n" + //false true    true true
                    $"GEO Scan Task Time:\t {eva.spec.time} seconds";
            }
            else if (eva.spec.started == true)
            {
                evaStatusGEO.text = $"GEO Scan Task Status:\t\t Ongoing\n" + //true false
                    $"GEO Scan Task Time:\t {eva.spec.time} seconds";
            }
            else
            {
                evaStatusGEO.text = $"GEO Scan Task Status:\t\t Not Assigned\n" + //false false
                    $"GEO Scan Task Time:\t {eva.spec.time} seconds";
            }
        }
    }

    void UpdateCommUI(Telemetry comm)
    {
        if (comm != null)
        {
            towerText.text = $"Communication Tower Online:\t {comm.comm_tower}";
        }
    }

    void UpdateDcuUI(Telemetry dcu)
    {
        if (dcu != null && dcu.eva1 != null)
        {
            if (dcu.eva1.batt == true)
            {
                dcuBatt1.text = "ON";
            }
            else
            {
                dcuBatt2.text = "OFF";
            }

            if (dcu.eva1.oxy == true)
            {
                dcuOxy1.text = "ON";
            }
            else
            {
                dcuOxy1.text = "OFF";
            }

            if (dcu.eva1.comm == true)
            {
                dcuComm1.text = "ON";
            }
            else
            {
                dcuComm1.text = "OFF";
            }

            if (dcu.eva1.fan == true)
            {
                dcuFan1.text = "ON";
            }
            else
            {
                dcuFan1.text = "OFF";
            }

            if (dcu.eva1.pump == true)
            {
                dcuPump1.text = "ON";
            }
            else
            {
                dcuPump1.text = "OFF";
            }

            if (dcu.eva1.co2 == true)
            {
                dcuCo2_1.text = "ON";
            }
            else
            {
                dcuCo2_1.text = "OFF";
            }
        }
    }

    void UpdateErrorUI(Telemetry error) //convert into if statments for DCU alerts
    {
        if (error != null)
        {
            errorText.text = $"Fan Error\t {error.fan_error} \n" +
                        $"Oxygen Pump\t {error.oxy_error} \n" +
                        $"Water Pump Error\t {error.pump_error} ";
        }
    }

    void UpdateImuUI(Telemetry imu)
    {
        if (imu != null && imu.eva1 != null)
        {
            imuText1.text = $"Your X Coordinate\t {imu.eva1.posx} longitude\n" +
                        $"Your Y Coordinate\t {imu.eva1.posy} latitude\n" +
                        $"Your Heading\t {imu.eva1.heading} �";
        }

        if (imu != null && imu.eva2 != null)
        {
            imuText2.text = $"Partner's X Coordinate\t {imu.eva2.posx} longitude\n" +
                        $"Partner's Y Coordinate\t {imu.eva2.posy} latitude\n" +
                        $"Partner's Heading\t {imu.eva2.heading} �";
        }
    }

    void UpdateRoverUI(Telemetry rover)
    {
        if (rover != null)
        {
            roverText.text = $"Rover X Coordinate\t {rover.posx} longitude\n" +
                        $"Rover Y Coordinate\t {rover.posy} latitude";
            //$"Oxygen\t {rover.posy} \n" +
            //$"Water Waste\t {rover.qr_id} ";
        }
    }

    void UpdateSpecUI(Telemetry spec)
    {
        if (spec != null && spec.eva1 != null)
        {
            var data = spec.eva1.data;

            siText1.text = $"{data.SiO2}%";
            tiText1.text = $"{data.TiO2}%";
            alText1.text = $"{data.Al2O3}%";
            feText1.text = $"{data.FeO}%";
            mnText1.text = $"{data.MnO}%";
            mgText1.text = $"{data.MgO}%";
            caText1.text = $"{data.CaO}%";
            kText1.text = $"{data.K2O}%";
            pText1.text = $"{data.P2O3}%";
            otherText1.text = $"{data.other}%";

            if (data.SiO2 == 30.75 && data.TiO2 == 0.92 && data.Al2O3 == 4.88 && data.FeO == 17.12 && data.MnO == 0.2 && data.MgO == 12.95 && data.CaO == 2.03 && data.K2O == 0.22 && data.P2O3 == 0.69)
            {
                typeBasalt1.text = "Mare Basalt";
            }
            else if (data.SiO2 == 25.9 && data.TiO2 == 0.88 && data.Al2O3 == 4.75 && data.FeO == 14.1 && data.MnO == 0.24 && data.MgO == 11.22 && data.CaO == 9.01 && data.K2O == 0.23 && data.P2O3 == 0.65)
            {
                typeBasalt1.text = "Vesicular Basalt";
            }
            else if (data.SiO2 == 36.64 && data.TiO2 == 0.92 && data.Al2O3 == 8.33 && data.FeO == 18.68 && data.MnO == 0.43 && data.MgO == 6.84 && data.CaO == 5.91 && data.K2O == 0.5 && data.P2O3 == 1.19)
            {
                typeBasalt1.text = "Olivine-1 Basalt";
            }
            else if (data.SiO2 == 38.29 && data.TiO2 == 1.47 && data.Al2O3 == 7.63 && data.FeO == 18.74 && data.MnO == 0.46 && data.MgO == 2.64 && data.CaO == 7.76 && data.K2O == 0.75 && data.P2O3 == 1.68)
            {
                typeBasalt1.text = "Feldspathic Basalt";
            }
            else if (data.SiO2 == 39.41 && data.TiO2 == 0.39 && data.Al2O3 == 1.94 && data.FeO == 29.3 && data.MnO == 0.71 && data.MgO == 19.27 && data.CaO == 3.8 && data.K2O == 0.12 && data.P2O3 == 0.3)
            {
                typeBasalt1.text = "Pigeonite Basalt";
            }
            else if (data.SiO2 == 40.36 && data.TiO2 == 0.99 && data.Al2O3 == 2.32 && data.FeO == 25.71 && data.MnO == 0.58 && data.MgO == 12.81 && data.CaO == 5.95 && data.K2O == 0.2 && data.P2O3 == 0.28)
            {
                typeBasalt1.text = "Olivine-2 Basalt";
            }
            else if (data.SiO2 == 43.98 && data.TiO2 == 1.04 && data.Al2O3 == 5.75 && data.FeO == 20.4 && data.MnO == 0.51 && data.MgO == 6.02 && data.CaO == 8.89 && data.K2O == 0.71 && data.P2O3 == 1.09)
            {
                typeBasalt1.text = "Ilmenite Basalt";
            }
            else
            {
                typeBasalt1.text = "Basalt Type Unknown";
            }
        }

        if (spec != null && spec.eva2 != null)
        {
            var data = spec.eva2.data;

            siText2.text = $"{data.SiO2}%";
            tiText2.text = $"{data.TiO2}%";
            alText2.text = $"{data.Al2O3}%";
            feText2.text = $"{data.FeO}%";
            mnText2.text = $"{data.MnO}%";
            mgText2.text = $"{data.MgO}%";
            caText2.text = $"{data.CaO}%";
            kText2.text = $"{data.K2O}%";
            pText2.text = $"{data.P2O3}%";
            otherText2.text = $"{data.other}%";

            if (data.SiO2 == 30.75 && data.TiO2 == 0.92 && data.Al2O3 == 4.88 && data.FeO == 17.12 && data.MnO == 0.2 && data.MgO == 12.95 && data.CaO == 2.03 && data.K2O == 0.22 && data.P2O3 == 0.69)
            {
                typeBasalt1.text = "Mare Basalt";
            }
            else if (data.SiO2 == 25.9 && data.TiO2 == 0.88 && data.Al2O3 == 4.75 && data.FeO == 14.1 && data.MnO == 0.24 && data.MgO == 11.22 && data.CaO == 9.01 && data.K2O == 0.23 && data.P2O3 == 0.65)
            {
                typeBasalt1.text = "Vesicular Basalt";
            }
            else if (data.SiO2 == 36.64 && data.TiO2 == 0.92 && data.Al2O3 == 8.33 && data.FeO == 18.68 && data.MnO == 0.43 && data.MgO == 6.84 && data.CaO == 5.91 && data.K2O == 0.5 && data.P2O3 == 1.19)
            {
                typeBasalt1.text = "Olivine-1 Basalt";
            }
            else if (data.SiO2 == 38.29 && data.TiO2 == 1.47 && data.Al2O3 == 7.63 && data.FeO == 18.74 && data.MnO == 0.46 && data.MgO == 2.64 && data.CaO == 7.76 && data.K2O == 0.75 && data.P2O3 == 1.68)
            {
                typeBasalt1.text = "Feldspathic Basalt";
            }
            else if (data.SiO2 == 39.41 && data.TiO2 == 0.39 && data.Al2O3 == 1.94 && data.FeO == 29.3 && data.MnO == 0.71 && data.MgO == 19.27 && data.CaO == 3.8 && data.K2O == 0.12 && data.P2O3 == 0.3)
            {
                typeBasalt1.text = "Pigeonite Basalt";
            }
            else if (data.SiO2 == 40.36 && data.TiO2 == 0.99 && data.Al2O3 == 2.32 && data.FeO == 25.71 && data.MnO == 0.58 && data.MgO == 12.81 && data.CaO == 5.95 && data.K2O == 0.2 && data.P2O3 == 0.28)
            {
                typeBasalt1.text = "Olivine-2 Basalt";
            }
            else if (data.SiO2 == 43.98 && data.TiO2 == 1.04 && data.Al2O3 == 5.75 && data.FeO == 20.4 && data.MnO == 0.51 && data.MgO == 6.02 && data.CaO == 8.89 && data.K2O == 0.71 && data.P2O3 == 1.09)
            {
                typeBasalt1.text = "Ilmenite Basalt";
            }
            else
            {
                typeBasalt1.text = "Basalt Type Unknown";
            }
        }
        /*if (spec != null && spec.eva1 != null) {
            geoText1.text = $"Si02\t\t {spec.eva1.data.SiO2} %\n" +
                        $"Ti02\t\t {spec.eva1.data.TiO2} %\n" +
                        $"Al203\t\t {spec.eva1.data.Al2O3} %\n" +
                        $"Fe0\t\t {spec.eva1.data.FeO} %\n" +
                        $"Mn0\t\t {spec.eva1.data.MnO} %\n" +
                        $"Mg0\t\t {spec.eva1.data.MgO} %\n" +
                        $"Ca0\t\t {spec.eva1.data.CaO} %\n" +
                        $"K20\t\t {spec.eva1.data.K2O} %\n" +
                        $"P203\t\t {spec.eva1.data.P2O3} %\n" +
                        $"Other\t\t {spec.eva1.data.other} %";
        }
        if (spec != null && spec.eva2 != null) {
            geoText2.text = $"Si02\t\t {spec.eva2.data.SiO2} %\n" +
                        $"Ti02\t\t {spec.eva2.data.TiO2} %\n" +
                        $"Al203\t\t {spec.eva2.data.Al2O3} %\n" +
                        $"Fe0\t\t {spec.eva2.data.FeO} %\n" +
                        $"Mn0\t\t {spec.eva2.data.MnO} %\n" +
                        $"Mg0\t\t {spec.eva2.data.MgO} %\n" +
                        $"Ca0\t\t {spec.eva2.data.CaO} %\n" +
                        $"K20\t\t {spec.eva2.data.K2O} %\n" +
                        $"P203\t\t {spec.eva2.data.P2O3} %\n" +
                        $"Other\t\t {spec.eva2.data.other} %";
        }*/
    }

    void UpdateUiaUI(Telemetry uia)
    {
        if (uia != null)
        {
            if (uia.eva1_water_supply == true) {
                supplyFlip1.value = 1.0f;
            }
            else {
                supplyFlip1.value = 0.0f;
            }

            if (uia.eva1_water_waste == true) {
                wasteFlip1.value = 1.0f;
            }
            else {
                wasteFlip1.value = 0.0f;
            }

            if (uia.eva1_power == true) {
                powerFlip1.value = 1.0f;
            }
            else {
                powerFlip1.value = 0.0f;
            }

            if (uia.eva1_oxy == true) {
                oxygenFlip1.value = 1.0f;
            }
            else {
                oxygenFlip1.value = 0.0f;
            }
    //uiaText1.text = $"Power\t {uia.eva1_power} \n" +
    //           $"Oxygen\t {uia.eva1_oxy} \n" +
    //           $"Water Supply\t {uia.eva1_water_supply} \n" +
    //           $"Water Waste\t {uia.eva1_water_waste} ";

            if (uia.eva2_water_supply == true) {
                supplyFlip2.value = 1.0f;
            }
            else {
                supplyFlip2.value = 0.0f;
            }

            if (uia.eva2_water_waste == true) {
                wasteFlip2.value = 1.0f;
            }
            else {
                wasteFlip2.value = 0.0f;
            }

            if (uia.eva2_power == true) {
                powerFlip2.value = 1.0f;
            }
            else {
                powerFlip2.value = 0.0f;
            }

            if (uia.eva2_oxy == true) {
                oxygenFlip2.value = 1.0f;
            }
            else {
                oxygenFlip2.value = 0.0f;
            }
            //uiaText2.text = $"Power\t {uia.eva2_power} \n" +
            //           $"Oxygen\t {uia.eva2_oxy} \n" +
            //           $"Water Supply\t {uia.eva2_water_supply} \n" +
            //           $"Water Waste\t {uia.eva2_water_waste} ";

            if (uia.oxy_vent == true) {
                ventFlip.value = 1.0f;
            }
            else {
                ventFlip.value = 0.0f;
            }

            if (uia.depress == true) {
                depressFlip.value = 1.0f;
            }
            else {
                depressFlip.value = 0.0f;
            }
            //uiaSide.text = $"Oxygen Vent\t {uia.oxy_vent} \n" +
            //           $"Depress\t {uia.depress} ";
        }
    }

}
