using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBehavior : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Transform player;
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameManager.onDialog){
            CheckInteraction();
        }
    }

    void CheckInteraction(){
        if(Vector3.Distance(transform.position, player.position) < 3.0f){
            transform.localScale = new Vector3(5.5f, 5.5f, 14.85f);
            if(Input.GetKeyDown(KeyCode.E)){
                gameManager.onDialog = true;
                StartCoroutine(TalkingToBob());
            }
        }else{
            transform.localScale = new Vector3(5.0f, 5.0f, 13.5f);
        }
    }

    IEnumerator TalkingToBob()
    {
        player.transform.LookAt(transform.parent.position);
        gameManager.talkingToBob = true;
        yield return new WaitForSeconds(5.0f);
        gameManager.talkedToBob = true;
        gameManager.onDialog = false;
        Destroy(gameObject);
    }
}
