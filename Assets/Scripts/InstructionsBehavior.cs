using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionsBehavior : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI instruction;
    private int phase = 0;

    // Start is called before the first frame update
    void Start()
    {
        instruction = GetComponent<TextMeshProUGUI>();
        instruction.text = "Press A, D to move";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0 && phase == 0)
        {
            instruction.text = "Press Space to jump";
            phase++;
        }else if(Input.GetKeyDown(KeyCode.Space) && phase == 1)
        {
            instruction.text = "";
            phase++;
        }
        
    }
}
