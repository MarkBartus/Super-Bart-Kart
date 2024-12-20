using Enemy;
using Player;
using System.Threading;
using UnityEngine;

public class objects : MonoBehaviour
{

    public float boostTimer = 1;
    public float enemyBoostTimer = 1;
    private bool boostActive = true;

    public bool isActive = true;
    

    private bool negSpeed = true;
    public float negTimer = 1;
    public float enemyNegTimer = 1;
    PlayerScript playerScript;
    EnemScript enemScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

     
    }

    // Update is called once per frame
    void Update()
    {
        if (boostActive == false && isActive == true)
        {
            boostTimer = boostTimer - Time.deltaTime;

            if (boostTimer <= 0 && playerScript != null)
            {
                playerScript.moveSpeed -= 2;
                boostActive = true;
            }
            if (enemyBoostTimer <= 0 && enemScript != null)
            {
                enemScript.moveSpeed -= 2;
                boostActive = true;
            }

        }

        if (negSpeed == false)
        {
            boostTimer = boostTimer - Time.deltaTime;

            if (negTimer <= 0 && playerScript != null)
            {
                playerScript.moveSpeed += 2;
                negSpeed = true;
            }
            if (enemyNegTimer <= 0 && enemScript != null)
            {
                enemScript.moveSpeed += 2;
                negSpeed = true;
            }

        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "mario_0"  && boostActive == true && isActive == true)
        {
            playerScript = other.GetComponent<PlayerScript>();
            playerScript.moveSpeed += 2;

            boostActive = false;

        }

        if (other.gameObject.name == "Koopatroopa" && boostActive == true && isActive == true)
        {
            enemScript = other.GetComponent<EnemScript>();
            enemScript.moveSpeed += 2;

            boostActive = false;

        }
        
        if (other.gameObject.name == "mario_0" && negSpeed == true && isActive == false)
        {
            enemScript = other.GetComponent<EnemScript>();
            enemScript.moveSpeed -= 2;

            negSpeed = false;

        }

        if (other.gameObject.name == "Koopatroopa" && negSpeed == true && isActive == false)
        {
            playerScript = other.GetComponent<PlayerScript>();
            playerScript.moveSpeed -= 2;

            negSpeed = false;

        }
        
    }
}
