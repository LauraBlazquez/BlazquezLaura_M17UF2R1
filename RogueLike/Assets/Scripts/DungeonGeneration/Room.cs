using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int Width, Height, X, Y;
    public Door up, left, down, right;
    private List<Flower> order = new List<Flower>();
    public List<Door> doors = new List<Door>();

    void Start()
    {
        if(RoomController.instance == null)
        {
            Debug.Log("Pressed play in the wrong scene!");
            return;
        }
        Door[] ds = GetComponentsInChildren<Door>();
        foreach(Door d in ds)
        {
            doors.Add(d);
            switch (d.doorType)
            {
                case Door.DoorType.up:
                    up = d; 
                break;
                case Door.DoorType.left:
                    left = d;
                break;
                case Door.DoorType.down:
                    down = d;
                break;
                case Door.DoorType.right:
                    right = d;
                break;
            }
        }
        RoomController.instance.RegisterRoom(this);
    }

    public void RemoveUnconnectedDoors()
    {
        foreach (Door door in doors)
        {
            int posX, posY;
            posX = posY = 0;
            switch (door.doorType)
            {
                case Door.DoorType.up:
                    posY = 1;
                    break;
                case Door.DoorType.left:
                    posX = -1;
                    break;
                case Door.DoorType.down:
                    posY = -1;
                    break;
                case Door.DoorType.right:
                    posX = 1;
                    break;
            }
            if (GetRoomByDoor(posX, posY) == null)
                door.gameObject.SetActive(false);
        }
    }

    public Room GetRoomByDoor(int posX, int posY)
    {
        if (RoomController.instance.DoesRoomExist(X + posX, Y + posY))
        {
            return RoomController.instance.FindRoom(X + posX, Y + posY);
        }
        return null;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(Width,Height, 0));
    }

    public Vector3 GetRoomCentre()
    {
        return new Vector3(X * Width, Y * Height);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            RoomController.instance.OnPlayerEnterRoom(this);
        }
    }
}
