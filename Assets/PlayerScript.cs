using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] GameObject doorSoundSource;
    [SerializeField] Image panel;
    [SerializeField] AudioListener listener;
    GameObject director;
    AudioSource[] doorSound;
    Ray rayCenter;
    RaycastHit hitCenter;
    bool isFinded;
    float delta;
    public static float clearTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        delta = 0;
        listener.enabled = true;
        director = GameObject.Find("GameDirector");
        doorSound = doorSoundSource.GetComponents<AudioSource>();
        panel.color = new Color(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        Click();
    }

    void Click() {
        if (Input.GetMouseButtonDown(0)) {
            rayCenter = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
            if (Physics.Raycast(rayCenter, out hitCenter, 5f)) {
                if (hitCenter.collider.gameObject.tag == "Door") {
                    DoorScript doorScript = hitCenter.collider.GetComponentInParent<DoorScript>();
                    doorScript.DoorClicked();
                    if (!doorScript.isOpen) {
                        doorSound[0].Play();
                    } else {
                        doorSound[1].Play();
                    }
                }
            }
        }
    }

    public void FindedEnemy() {
        if(isFinded == false) {
            isFinded = true;
            director.GetComponent<ChangeBGM>().Change();
            panel.color = new Color(20f / 255f, 20f / 255f, 20f / 255f, 70f / 255f);
        }
    }

    void Clear() {
        clearTime = delta;
        listener.enabled = false;
        FadeManager.Instance.fadeColor = Color.white;
        FadeManager.Instance.LoadScene("Clear", 2f);
    }

    void GameOver() {
        listener.enabled = false;
        panel.color = Color.black;
        SceneManager.LoadSceneAsync("GameOver");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy") {
            GameOver();
        }
        if (other.gameObject.tag == "Treasure") {
            Clear();
        }
    }
}
