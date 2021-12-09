using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCtrl : MonoBehaviour
{
    // Inte bra med att använda en singelton för en level specifik information
    // bör byggas på ett annat sätt för att det ska vara stabilt
    // den lösningen jag gör nu är inte heller den bästa utan den enkla som jag tror funkar i detta fall :)

    //public MainCtrl gameCtrl;
    public int PatientAmount;
    public float Time;
    public float Health;
    public GameObject EndPanel;
    public bool END = false;

    private void Awake()
    {
        /* // det här gör att kameran blir kvar i scenen och att panelens koppling bryts.
        if (gameCtrl == null)
        { gameCtrl = this; }
        else if (gameCtrl != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        */

        if (EndPanel != null)
        {
            EndPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Missing End panel in Level Manager - MainCtrl script ! ending will not work");
        }

    }
    void Update()
    {
        
        if(PatientAmount <= 0 && END && EndPanel != null)
        {
            EndPanel.SetActive(true);
            EndPanel.GetComponent<Results>().SetResults(Time, Health);
        }

    }

}
