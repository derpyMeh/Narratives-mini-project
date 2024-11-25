using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MakeDecision : MonoBehaviour
{
    public enum WorldLocation { MiddlePompei, Harbour, Smith}

    //[Header("Location name")]
    //public string LocationText = "undefined";

    [Header("Location to go to")]
    public WorldLocation Location;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GotoScene();
        } 
    }

    private void GotoScene()
    {
        if(SceneManager.GetActiveScene().buildIndex + 1 <= SceneManager.sceneCount) // If there is more avaliable scenes 
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
        Debug.Log("Next scene loaded");
    }
}
