using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionsBehavior : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI instruction;
    private int phase = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        instruction = GetComponent<TextMeshProUGUI>();
        instruction.text = "Press A, D to move";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0 && phase == 0)
        {
            instruction.text = "Talk to Bob (Press E)";
            phase++;
        }else if(gameManager.talkingToBob && phase == 1)
        {
            instruction.text = "\"Hello, Stranger!\"";
            phase++;
        }else if(gameManager.talkedToBob && phase == 2){
            instruction.text = "...";
            phase++;
        }
        
    }
}
