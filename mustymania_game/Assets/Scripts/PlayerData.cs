using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    //public int level;
    //public int health;
    public float[] position;
    public float[] rotation;
    public bool facingRight;

    public PlayerData(Player player)
    {
        //level = player.level;
        //health = player.health;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        rotation = new float[4];
        rotation[0] = player.transform.rotation.x;
        rotation[1] = player.transform.rotation.y;
        rotation[2] = player.transform.rotation.z;
        rotation[3] = player.transform.rotation.w;

        facingRight = player.controller.GetFacingRight();

    }
}
