using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
//using TMPr;
//using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MakeDecision : MonoBehaviour
{
    [Header("Location to go to")]
    public PersistentManager.WorldLocation Location;

    private TextMesh textMesh;

    private BoxCollider boxcollider;
    private void Start()
    {
        boxcollider = GetComponentInChildren<BoxCollider>();

        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = Location.ToString();
        //text
        //textMeshPro = GetComponentInChildren<TextMesh>();

        //Debug.Log("tets:"+ textMeshPro);
        //textMeshPro.text = Location.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            boxcollider.enabled = false;
            PersistentManager.Instance.GotoScene(Location);
        }
    }
}
