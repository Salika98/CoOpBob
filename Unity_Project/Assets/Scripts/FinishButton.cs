using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishButton : MonoBehaviour {

	 void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Player")
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            if(playerController.GetPlayerNum() == 2)
            {
            	UIManager.finishGame();
            }
       }
    }
}
