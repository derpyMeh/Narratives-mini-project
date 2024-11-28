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

    //private TextMeshProUGUI textMeshPro;

    private CapsuleCollider capsuleCollider;
    private void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();

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
