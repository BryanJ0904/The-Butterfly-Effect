using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject tree;
    [SerializeField] private Material mat;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(counter <= 1000){
            Vector3 position = new Vector3(Random.Range(-200f, 200f), 0.4f, Random.Range(10f, 500));
            GameObject newTree = Instantiate(tree, position, Quaternion.identity, this.transform);
            newTree.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = mat;
            newTree.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = mat;
            counter++;
        }
    }
}
