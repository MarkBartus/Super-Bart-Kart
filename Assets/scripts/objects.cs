using Enemy;
using Player;
using System.Threading;
using UnityEngine;

public class objects : MonoBehaviour
{

    public float boostTimer = 1;
    public float enemyBoostTimer = 1;
    public bool boostActive = true;

    PlayerScript playerScript;
    EnemScript enemScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

     
    }

    // Update is called once per frame
    void Update()
    {
        if (boostActive == false)
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
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "mario_0"  && boostActive == true)
        {
            playerScript = other.GetComponent<PlayerScript>();
            playerScript.moveSpeed += 2;

            boostActive = false;

        }

        if (other.gameObject.name == "Koopatroopa" && boostActive == true)
        {
            enemScript = other.GetComponent<EnemScript>();
            enemScript.moveSpeed += 2;

            boostActive = false;

        }
    }
}
