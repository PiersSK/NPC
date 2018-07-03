using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobility : MonoBehaviour {
	//Inspector Variables
    public float playerSpeed; //speed player moves
    public GameObject camera;
<<<<<<< Updated upstream
=======

    public Vector2 knockbackDirection;
    public float knockbackMultiplier;
    public float knockbackCount;

    public float attackCount;

    public bool isInvincible;

>>>>>>> Stashed changes
    private Vector3 offset;
    private Vector3 spawnPoint;

    private Animator playerAnimator;
<<<<<<< Updated upstream
=======
    private Rigidbody2D playerRB;
    private SpriteRenderer playerSprite;

>>>>>>> Stashed changes
    private static float faceX;
    private static float faceY;

    void Start () {
        SetSpawnPoint();

        playerAnimator = GetComponent<Animator>();
<<<<<<< Updated upstream
=======
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        playerSprite = gameObject.GetComponent<SpriteRenderer>();

>>>>>>> Stashed changes
        playerAnimator.Play("Idle");
    }
   
    void Update () {
       if(!TextBoxRenderer.persistText) MoveForward();
    }

    void SetSpawnPoint() {
<<<<<<< Updated upstream
        int returningFromRoom = PlayerPrefs.GetInt("returningFromRoom"); //1 = true, 0 = false
        spawnPoint = returningFromRoom == 1
            ? new Vector3(12.5f, 8.3f, 0)
            : new Vector3(0, 0, 0);
=======
        // int returningFromScene = PlayerPrefs.GetInt("returningFromScene"); //1 = true, 0 = false
        Vector3 savedSpawnPoint = new Vector3(PlayerPrefs.GetFloat("spawnX"), PlayerPrefs.GetFloat("spawnY"), PlayerPrefs.GetFloat("spawnZ"));

        spawnPoint = savedSpawnPoint;

>>>>>>> Stashed changes
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
            if(attackCount <= 0) playerAnimator.Play("Moving");
        } else {
            if(attackCount <= 0) playerAnimator.Play("Idle");
        }

<<<<<<< Updated upstream
        transform.Translate(xInput * playerSpeed, yInput * playerSpeed, 0);
=======
        // transform.Translate(xInput * playerSpeed * Time.deltaTime, yInput * playerSpeed * Time.deltaTime, 0);
        if(knockbackCount <= 0 && attackCount <= 0) {
            playerSprite.color = new Color(255, 255, 255);
            playerRB.velocity = new Vector2(xInput, yInput) * playerSpeed; //removes vibrations
        } else if (attackCount <=0 && knockbackCount >= 0) {
            playerSprite.color = new Color(255, 0, 0);
            playerRB.velocity = knockbackDirection * knockbackMultiplier;
            knockbackCount -= Time.deltaTime;
        } else {
            playerAnimator.Play("Attacking");
            attackCount -= Time.deltaTime;
        }
>>>>>>> Stashed changes
    }

    public static Vector2 GetPlayerDirection() {
        return new Vector2(faceX, faceY);
    }
}
