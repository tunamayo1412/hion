using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool isOpen;
    SimpleAnimation simpleAnim;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        simpleAnim = GetComponent<SimpleAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoorClicked() {
        if (isOpen) {
            simpleAnim.Play("Close");
            isOpen = false;
        } else {
            simpleAnim.Play("Open");
            isOpen = true;
        }
    }
}
