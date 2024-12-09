using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PersistentManager;
using static UnityEditor.FilePathAttribute;

public class MovePlayerToCurrentLocation : MonoBehaviour
{
    private void Start()
    {
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Moving the player to the position of the location marker..
        switch (PersistentManager.Instance.NextLocation)
        {
            case WorldLocation.Alley:
                playerTransform.position = GameObject.FindGameObjectWithTag("Location_Alley").transform.position;
                Debug.Log("Moved player to WorldLocation.Alley");
                break;
            case WorldLocation.Smith:
                playerTransform.position = GameObject.FindGameObjectWithTag("Location_Smith").transform.position;
                Debug.Log("Moved player to  WorldLocation.Smith");

                break;
            case WorldLocation.Harbour:
                playerTransform.position = GameObject.FindGameObjectWithTag("Location_Harbour").transform.position;
                Debug.Log("Moved player to  WorldLocation.Harbour");
                break;
            case WorldLocation.Market:
                playerTransform.position = GameObject.FindGameObjectWithTag("Location_Market").transform.position;
                Debug.Log("Moved player to  WorldLocation.Market");
                break;
            case WorldLocation.Villa:
                playerTransform.position = GameObject.FindGameObjectWithTag("Location_Villa").transform.position;
                Debug.Log("Moved player to  WorldLocation.Villa");
                break;
            case WorldLocation.Outskirts:
                playerTransform.position = GameObject.FindGameObjectWithTag("Location_Outskirts").transform.position;
                Debug.Log("Moved player to  WorldLocation.Outskirts");
                break;
            default:
                Debug.LogError("No location found!");
                break;
        }
    }
}
