using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;
    Vector3 maju = Vector3.zero;
    float kecepatan = 3f;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    void Update () {
        if(!gameManager.onDialog){
            PlayerMovement();
        }else{

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
                this.GetComponent<Animator>().SetBool("isRunning", true);
            }else{
                kecepatan = 3.0f;
                this.GetComponent<Animator>().SetBool("isRunning", false);
            }
            this.GetComponent<Animator>().SetBool("isWalking", true);
        } else {
            this.GetComponent<Animator>().SetBool("isWalking", false);
        }
    }
}
