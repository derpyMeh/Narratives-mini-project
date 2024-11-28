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

    private CapsuleCollider capsuleCollider;
    private void Start()
    {
        capsuleCollider = GetComponentInChildren<CapsuleCollider>();

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
            capsuleCollider.enabled = false;
            PersistentManager.Instance.GotoScene(Location);
        }
    }
}
