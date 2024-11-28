using UnityEngine;
using static UnityEditor.FilePathAttribute;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PersistentManager : MonoBehaviour
{
    public enum WorldLocation { MiddlePompei, Harbour, Smith }
    // Singleton instance
    public static PersistentManager Instance { get; private set; }

    // String values
    [SerializeField]
    public int SceneID;
    public WorldLocation CurrentLocation;
    public WorldLocation NextLocation;

    //public Transform playerTransform;

    private void Awake()
    {
        // Ensure only one instance of the manager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist through scene loads
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }

        //playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void GotoScene(WorldLocation location)
    {
        NextLocation = location;

        if (SceneManager.GetActiveScene().buildIndex + 1 <= SceneManager.sceneCount)
        {// if there is more avaliable scenes 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);

            //Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

            //// Moving the player to the position of the location marker..
            //switch (location)
            //{
            //    case WorldLocation.MiddlePompei:
            //        playerTransform.position = GameObject.FindGameObjectWithTag("Location_MiddlePompei").transform.position;
            //        break;
            //    case WorldLocation.Smith:
            //        playerTransform.position = GameObject.FindGameObjectWithTag("Location_Smith").transform.position;
            //        break;
            //    case WorldLocation.Harbour:
            //        playerTransform.position = GameObject.FindGameObjectWithTag("Location_Harbour").transform.position;
            //        break;
            //    default:
            //        Debug.LogError("No location found!");
            //        break;
            //}
        }
        Debug.Log("next scene loaded");
    }
}
