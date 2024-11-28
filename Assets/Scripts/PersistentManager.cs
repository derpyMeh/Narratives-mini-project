using UnityEngine;
using static UnityEditor.FilePathAttribute;
using UnityEngine.SceneManagement;
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

    // Optional: Method to print debug information
    public void PrintStatus()
    {
        Debug.Log($"Current Scene: {SceneID}, Current Location: {CurrentLocation}, Next Location: {NextLocation}");
    }

    public void GotoScene(WorldLocation location)
    {
        NextLocation = location;

        if (SceneManager.GetActiveScene().buildIndex + 1 <= SceneManager.sceneCount) // if there is more avaliable scenes 
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
        Debug.Log("next scene loaded");
    }

}
