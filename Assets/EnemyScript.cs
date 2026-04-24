using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    GameObject player;
    PlayerScript playerScript;
    Ray ray;
    Vector3 distance;
    RaycastHit hit;
    NavMeshAgent agent;
    Vector3 destination;
    Animator animator;
    AudioSource doorOpen;
    int MapSize = 11;
    [SerializeField] int posX, posZ;
    int direction;  // 0: 右, 1: 上, 2: 左, 3: 下
    int originPosition;
    int tmpDirection;
    bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        animator = GetComponent<Animator>();
        doorOpen = GetComponent<AudioSource>();
        tmpDirection = -1;
        /*if (Random.Range(0, 2) == 1) {
            posX = 0;
        } else {
            posX = MapSize - 1;
        }
        if (Random.Range(0, 2) == 1) {
            posZ = 0;
        } else {
            posZ = MapSize - 1;
        }
        agent.Warp(new Vector3((posX * 8) - 4, 2, (posZ * 8) - 4));*/
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isRunning) Move();
        Run();
    }

    void Move() {
        //移動が完了するまで待機
        if(agent.remainingDistance <= 2) {
            //移動できる方向が出るまで再抽選
            while ((posX == 0 && direction == 2) || (posX == MapSize - 1 && direction == 0) || (posZ == 0 && direction == 3) || (posZ == MapSize - 1 && direction == 1) || direction == -1 || Mathf.Abs(direction - tmpDirection) == 2) {
                direction = Random.Range(0, 4);
            }
            switch (direction) {
                case 0:
                    destination += new Vector3(8, 0, 0);
                    posX++;
                    Debug.Log("right");
                    break;
                case 1:
                    destination += new Vector3(0, 0, 8);
                    posZ++;
                    Debug.Log("up");
                    break;
                case 2:
                    destination += new Vector3(-8, 0, 0);
                    posX--;
                    Debug.Log("left");
                    break;
                case 3:
                    destination += new Vector3(0, 0, -8);
                    posZ--;
                    Debug.Log("down");
                    break;
            }
            agent.destination = destination;
            animator.SetBool("isWalking", true);
            tmpDirection = direction;
            direction = -1;
        }
    }

    void Run() {
        distance = player.transform.position - transform.position;
        ray = new Ray(transform.position, distance.normalized);
        Debug.DrawRay(ray.origin, distance, Color.red);
        Physics.Raycast(ray, out hit, distance.magnitude);
        if(hit.transform.gameObject.tag == "Player") {
            isRunning = true;
            animator.SetBool("IsRunning", true);
            agent.speed = 8;
            playerScript.FindedEnemy();
        }
        if(isRunning) {
            agent.SetDestination(player.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Door") {
            DoorScript doorScript = other.gameObject.GetComponentInParent<DoorScript>();
            if (!doorScript.isOpen) {
                doorScript.DoorClicked();
                doorOpen.Play();
            }
        }
    }
}
