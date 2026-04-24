using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TresureScript : MonoBehaviour {
    // Start is called before the first frame update
    NavMeshAgent agent;
    Vector3 destination;
    int MapSize = 11;
    [SerializeField] int posX, posZ;
    int direction;  // 0: 右, 1: 上, 2: 左, 3: 下
    int tmpDirection;
    bool positionIsSet;

    // Start is called before the first frame update
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        if (Random.Range(0, 2) == 1) {
            posX = 0;
        } else {
            posX = MapSize - 1;
        }
        if (Random.Range(0, 2) == 1) {
            posZ = 0;
        } else {
            posZ = MapSize - 1;
        }
        agent.Warp(new Vector3((posX * 8) - 4, 2, (posZ * 8) - 4));
        destination = transform.position;
        tmpDirection = -100;
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    void Move() {
        //移動が完了するまで待機
        if (agent.remainingDistance <= 2) {
            //移動できる方向が出るまで再抽選
            while ((posX == 0 && direction == 2) || (posX == MapSize - 1 && direction == 0) || (posZ == 0 && direction == 3) || (posZ == MapSize - 1 && direction == 1) || direction == -100 || Mathf.Abs(direction - tmpDirection) == 2) {
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
            tmpDirection = direction;
            direction = -100;
        }
    }
}
