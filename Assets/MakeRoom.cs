using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MakeRoom : MonoBehaviour
{
    [SerializeField] GameObject DoorRoom, Room, lefDoorRoom, lefRoom, rigDoorRoom, rigRoom, upDoorRoom, upRoom, dowDoorRoom, dowRoom, lefupRoom, lefdowRoom, rigupRoom, rigdowRoom;
    [SerializeField] GameObject treasure;
    NavMeshSurface navSurface;
    int mapSize = 11;
    int treasureNumber = 3;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < mapSize; i++) {
            for(int j = 0; j < mapSize; j++) {
                GameObject room = null;
                if ((i + j) % 2 == 0) {  //ドアあり
                    if (i == 0 || i == mapSize - 1 || j == 0 || j == mapSize - 1) {
                        if (i == 0 && j == 0) room = Instantiate(rigupRoom) as GameObject;
                        if (i == 0 && j == mapSize - 1) room = Instantiate(rigdowRoom) as GameObject;
                        if (i == mapSize - 1 && j == mapSize - 1) room = Instantiate(lefdowRoom) as GameObject;
                        if (i == mapSize - 1 && j == 0) room = Instantiate(lefupRoom) as GameObject;

                        if (i == 0 && j != 0 && j != mapSize - 1) room = Instantiate(rigDoorRoom) as GameObject;
                        if (i == mapSize - 1 && j != 0 && j != mapSize - 1) room = Instantiate(lefDoorRoom) as GameObject;
                        if (i != 0 && i != mapSize - 1 && j == 0) room = Instantiate(upDoorRoom) as GameObject;
                        if (i != 0 && i != mapSize - 1 && j == mapSize - 1) room = Instantiate(dowDoorRoom) as GameObject;
                    } else {
                        room = Instantiate(DoorRoom) as GameObject;
                    }
                } else {                //ドアなし
                    if (i == 0 || i == mapSize - 1 || j == 0 || j == mapSize - 1) {
                        if (i == 0 && j != 0 && j != mapSize - 1) room = Instantiate(rigRoom) as GameObject;
                        if (i == mapSize - 1 && j != 0 && j != mapSize - 1) room = Instantiate(lefRoom) as GameObject;
                        if (i != 0 && i != mapSize - 1 && j == 0) room = Instantiate(upRoom) as GameObject;
                        if (i != 0 && i != mapSize - 1 && j == mapSize - 1) room = Instantiate(dowRoom) as GameObject;
                    } else {
                        room = Instantiate(Room) as GameObject;
                    }
                }
                room.transform.position = new Vector3(i * 8, 0, j * 8);
            }
        }

        navSurface = GetComponent<NavMeshSurface>();
        navSurface.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
