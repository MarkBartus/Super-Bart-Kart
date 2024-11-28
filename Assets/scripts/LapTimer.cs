using UnityEngine;
using TMPro;

public class LapTimer : MonoBehaviour
{

    public float lapTimer;

    public bool startTimer = false;

    

    private int laps;

    public TextMeshProUGUI lTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (startTimer == true)
        {
            lapTimer = lapTimer + Time.deltaTime;

            //Debug.Log(lapTimer);
            lTime.text = "Time: " + lapTimer.ToString("F2");

        }

        if (laps == 3)
        {
            //finish game

            lapTimer = lapTimer;
        }
    }

    void OnTriggerEnter(Collider other)
    {  
        if(other.gameObject.name == "mario_0")
        {
            startTimer = true;
 

            laps = laps + 1;

            Debug.Log(laps);
        }



        


    }
}
