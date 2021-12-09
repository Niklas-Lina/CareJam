using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCtrl : MonoBehaviour
{
    // Inte bra med att anv�nda en singelton f�r en level specifik information
    // b�r byggas p� ett annat s�tt f�r att det ska vara stabilt
    // den l�sningen jag g�r nu �r inte heller den b�sta utan den enkla som jag tror funkar i detta fall :)

    //public MainCtrl gameCtrl;
    public int PatientAmount;
    public float Time;
    public float Health;
    public GameObject EndPanel;
    public bool END = false;

    private void Awake()
    {
        /* // det h�r g�r att kameran blir kvar i scenen och att panelens koppling bryts.
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
