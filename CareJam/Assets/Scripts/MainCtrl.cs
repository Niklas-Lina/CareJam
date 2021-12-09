using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCtrl : MonoBehaviour
{
    public static MainCtrl gameCtrl;
    public int PatientAmount;
    public float Time;
    public float Health;
    public GameObject EndPanel;
    public bool END = false;

    private void Awake()
    {

        if (gameCtrl == null)
        { gameCtrl = this; }
        else if (gameCtrl != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        if(EndPanel != null)
        EndPanel.SetActive(false);

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
