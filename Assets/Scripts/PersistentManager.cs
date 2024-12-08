using UnityEngine;
using static UnityEditor.FilePathAttribute;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PersistentManager : MonoBehaviour
{
    public enum WorldLocation { Alley, Harbour, Smith, Villa, Market, Outskirts, EscapeFromOutskirts, EscapeFromHarbour }
    // Singleton instance
    public static PersistentManager Instance { get; private set; }

    // String values
    [SerializeField]
    public int SceneID;
    public WorldLocation CurrentLocation;
    public WorldLocation NextLocation;

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
    }

    public void GotoScene(WorldLocation location)
    {
        NextLocation = location;

        //if (SceneID + 1 <= SceneManager.sceneCount)
        //{// if there is more avaliable scenes 
            SceneManager.LoadScene(SceneID + 1, LoadSceneMode.Single);
            SceneID++;

            Debug.Log("next scene loaded");
        //}
       
    }
}
