using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

	[SerializeField]
	string triggerObject;
	[SerializeField]
	int playerNum;
	[SerializeField]
	float finalYposition;

	 void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Player")
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            if(playerController.GetPlayerNum() == playerNum)
            {
            GameObject platform;
            platform = GameObject.FindGameObjectWithTag(triggerObject);
            Vector3 platformInfo = platform.transform.transform.position;
            Vector3 finalPosition = new Vector3(platformInfo.x, finalYposition, platformInfo.z);
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
