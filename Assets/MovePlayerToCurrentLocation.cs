using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PersistentManager;
using static UnityEditor.FilePathAttribute;

public class MovePlayerToCurrentLocation : MonoBehaviour
{
    private void OnEnable()
    {
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Moving the player to the position of the location marker..
        switch (PersistentManager.Instance.NextLocation)
        {
            case WorldLocation.MiddlePompei:
                playerTransform.position = GameObject.FindGameObjectWithTag("Location_MiddlePompei").transform.position;
                Debug.Log("Moved player to WorldLocation.MiddlePompei");
                break;
            case WorldLocation.Smith:
                playerTransform.position = GameObject.FindGameObjectWithTag("Location_Smith").transform.position;
                Debug.Log("Moved player to  WorldLocation.Smith");

                break;
            case WorldLocation.Harbour:
                playerTransform.position = GameObject.FindGameObjectWithTag("Location_Harbour").transform.position;
                Debug.Log("Moved player to  WorldLocation.Harbour");
                break;
            default:
                Debug.LogError("No location found!");
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
