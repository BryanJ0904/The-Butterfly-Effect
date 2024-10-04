using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 maju = Vector3.zero;
    float kecepatan = 3f;
    
    void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if(h!=0 || v!=0) {
            Vector3 targetDirection = new Vector3(h, 0f, v);
            targetDirection = Camera.main.transform.TransformDirection(targetDirection);
            targetDirection.y = 0.0f;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            this.transform.rotation = targetRotation;
            this.transform.position += Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up) * v * Time.deltaTime * kecepatan;
            this.transform.position += Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up) * h * Time.deltaTime * kecepatan;
            this.GetComponent<Animator>().SetBool("isWalking", true);
        } else {
            this.GetComponent<Animator>().SetBool("isWalking", false);
        }
    }
}
