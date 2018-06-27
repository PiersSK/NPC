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
    private Rigidbody2D playerRB;
    private static float faceX;
    private static float faceY;

    void Start () {
        SetSpawnPoint();
        playerAnimator = GetComponent<Animator>();
        playerAnimator.Play("Idle");
        playerRB = gameObject.GetComponent<Rigidbody2D>();
    }
   
    void Update () {
        MoveForward();
    }

    void SetSpawnPoint() {
        int returningFromScene = PlayerPrefs.GetInt("returningFromScene"); //1 = true, 0 = false
        Vector3 savedSpawnPoint = new Vector3(PlayerPrefs.GetFloat("spawnX"), PlayerPrefs.GetFloat("spawnY"), 0);

        spawnPoint = returningFromScene == 1
            ? savedSpawnPoint
            : new Vector3(0, 0, 0);

        offset = camera.transform.position - transform.position;
        transform.position = spawnPoint;
        camera.transform.position = spawnPoint + offset;

        setSpawnDefaults();
    }

    void setSpawnDefaults() {
        PlayerPrefs.SetInt("returningFromScene", 0);
        PlayerPrefs.SetFloat("spawnX", 0);
        PlayerPrefs.SetFloat("spawnY", 0);
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

        // transform.Translate(xInput * playerSpeed * Time.deltaTime, yInput * playerSpeed * Time.deltaTime, 0);

        playerRB.velocity = new Vector3(xInput, yInput) * playerSpeed; //removes vibrations
    }

    public static Vector2 GetPlayerDirection() {
        return new Vector2(faceX, faceY);
    }
}
