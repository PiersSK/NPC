using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobility : MonoBehaviour {
	//Inspector Variables
    public float playerSpeed; //speed player moves
    public GameObject camera;
    private Vector3 offset;
    private Vector3 spawnPoint;
    private Animator playerAnimator;
    private static float faceX;
    private static float faceY;

    void Start () {
        SetSpawnPoint();
        playerAnimator = GetComponent<Animator>();
        playerAnimator.Play("Idle");
    }
   
    void Update () {
        MoveForward();
    }

    void SetSpawnPoint() {
        int returningFromRoom = PlayerPrefs.GetInt("returningFromRoom"); //1 = true, 0 = false
        spawnPoint = returningFromRoom == 1
            ? new Vector3(12.5f, 8.3f, 0)
            : new Vector3(0, 0, 0);
        offset = camera.transform.position - transform.position;
        transform.position = spawnPoint;
        camera.transform.position = spawnPoint + offset;
        PlayerPrefs.SetInt("returningFromRoom", 0);
    }

    void MoveForward() {
        var xInput = Input.GetAxisRaw("Horizontal");
        var yInput = Input.GetAxisRaw("Vertical");

        if( xInput != 0 || yInput != 0 ) {
            faceX = xInput;
            faceY = yInput;
            playerAnimator.SetFloat("FaceX", faceX);
            playerAnimator.SetFloat("FaceY", faceY);
            playerAnimator.Play("Moving");
        } else {
            playerAnimator.Play("Idle");
        }

        transform.Translate(xInput * playerSpeed * Time.deltaTime, yInput * playerSpeed * Time.deltaTime, 0);
    }

    public static Vector2 GetPlayerDirection() {
        return new Vector2(faceX, faceY);
    }
}
