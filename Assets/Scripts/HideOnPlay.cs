using UnityEngine;

public class HideOnPlay : MonoBehaviour
{
    void Start()
    {
        foreach (MeshRenderer renderer in GetComponentsInChildren<MeshRenderer>())
        {
            renderer.enabled = false;
        }

        //foreach (TextMesh textMesh in GetComponentsInChildren<TextMesh>())
        //{
        //    textMesh
        //}
        //GetComponentInChildren<TMP_Text>().enabled = false;
    }
}
