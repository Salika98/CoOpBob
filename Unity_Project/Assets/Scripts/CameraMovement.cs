using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float cameraOffsetY = 10;
    public float cameraOffsetZ = 10;
    private Camera mainCamera;
    private GameObject player;
    private GameObject player2;
    private GameObject p;
    private int flag =0;
    private Vector3 playerInfo;

    // Use this for initialization
    void Start () {

        mainCamera = GetComponent<Camera>();
        player = GameObject.Find("Player_1");
        player2 = GameObject.Find("Player_2");
        p = player;
    }
    
    // Update is called once per frame
    void Update () {
        //switches between the players
        if (Input.GetKeyDown("v")){
            if(flag==0){

              p = player2; flag=1;

            }else{ p = player; flag=0;}
           }
       playerInfo = p.transform.transform.position; 
        mainCamera.transform.position = new Vector3(playerInfo.x, playerInfo.y + cameraOffsetY, playerInfo.z - cameraOffsetZ);
    }
}
