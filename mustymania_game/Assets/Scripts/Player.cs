using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // will store level, health, etc. here .... used for saving (PlayerData script)
    //public int level;
    //public int health;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);

        Debug.Log("Saved!");
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        //level = data.level;
        //health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        Quaternion rotation;
        rotation.x = data.rotation[0];
        rotation.y = data.rotation[1];
        rotation.z = data.rotation[2];
        rotation.w = data.rotation[3];
        transform.rotation = rotation;


        Debug.Log("Loaded!");
    }

}
