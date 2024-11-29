using UnityEngine;
using TMPro;

public class LapTimer : MonoBehaviour
{

    public float lapTimer;

    public bool startTimer = false;

    public GameObject background;

    private int laps;

    public TextMeshProUGUI lTime;
    public TextMeshProUGUI fTime;
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
            Time.timeScale = 0;
           // Debug.Log("game end");
            startTimer = false;
            
            background.SetActive(true);

            fTime.text = "Finishd Time: " + lapTimer.ToString("F2");
        }
    }

    void OnTriggerEnter(Collider other)
    {  
        if(other.gameObject.name == "mario_0")
        {
            startTimer = true;
 

            laps = laps + 1;

           // Debug.Log(laps);
        }


    }
}
