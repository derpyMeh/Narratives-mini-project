using UnityEngine;

public class HideOnPlay : MonoBehaviour
{
    void Start()
    {
        foreach (Transform t in GetComponentInChildren<Transform>())
        {
            t.gameObject.SetActive(false);
        }
        //GetComponentInChildren<TMP_Text>().enabled = false;
    }

    void Update()
    {
        
    }
}
