using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatform : MonoBehaviour {

	private int collectedCoins = 0;
	 void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            if(playerController)
            {
            	int amount = playerController.CoinCounter();
                collectedCoins += amount;
                playerController.Coins(-amount);
            }
            if(collectedCoins == 10){
            	GameObject platform;
            platform = GameObject.FindGameObjectWithTag("Movable3");
            Vector3 platformInfo = platform.transform.transform.position;
            Vector3 finalPosition = new Vector3(platformInfo.x, -3.5f, platformInfo.z);
            MovePlatform(platform, platformInfo, finalPosition);
            }
        }
    }

    void MovePlatform(GameObject platform, Vector3 platformInfo, Vector3 finalPosition)
    {
        float t = 0f;
        while (t < 10.0f)
        {
            t += Time.deltaTime * 0.01f;
            platform.transform.position = Vector3.Lerp(platformInfo, finalPosition, t);
        }
    }

}