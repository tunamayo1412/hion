using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                if(hit.collider.gameObject.tag == "Door") {
                    GetComponent<AudioSource>().Play();
                    hit.collider.gameObject.GetComponentInParent<DoorScript>().DoorClicked();
                    FadeManager.Instance.fadeColor = Color.black;
                    FadeManager.Instance.LoadScene("Main", 1f);
                }
            }
        }
    }
}
