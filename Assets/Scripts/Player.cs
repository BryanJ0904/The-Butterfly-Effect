using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;
    private Vector3 maju = Vector3.zero;
    private float kecepatan = 3f;
    private AudioSource footstep;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        footstep = GetComponent<AudioSource>();
    }
    
    void Update () {
        if(!gameManager.onDialog){
            PlayerMovement();
        }else{
            this.GetComponent<Animator>().SetBool("isRunning", false);
            this.GetComponent<Animator>().SetBool("isWalking", false);
        }
    }

    void PlayerMovement(){
        float h = Input.GetAxis("Horizontal");
        if(h!=0) {
            Vector3 targetDirection = new Vector3(h, 0f, 0f);
            targetDirection = Camera.main.transform.TransformDirection(targetDirection);
            targetDirection.y = 0.0f;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            this.transform.rotation = targetRotation;
            this.transform.position += Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up) * h * Time.deltaTime * kecepatan;
            if(Input.GetKey(KeyCode.LeftShift)){
                kecepatan = 5.0f;
                footstep.pitch = 1.25f;
                this.GetComponent<Animator>().SetBool("isRunning", true);
            }else{
                kecepatan = 3.0f;
                footstep.pitch = 1f;
                this.GetComponent<Animator>().SetBool("isRunning", false);
            }

            if (!footstep.isPlaying) {
                    footstep.Play();
            }
            this.GetComponent<Animator>().SetBool("isWalking", true);
        } else {
            if (footstep.isPlaying) {
                    footstep.Stop();
            }
            this.GetComponent<Animator>().SetBool("isWalking", false);
        }
    }
}
