using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintball : MonoBehaviour
{
    public List<Material> ourPaints = new List<Material>();
    //public Material materialToAdd;
    static private int paintIndex;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Paintable")
        {
            //increase list size (i forget how..)
            //ourPaints.Add(materialToAdd);
            int ListSize = ourPaints.Count;
            collision.collider.GetComponent<Renderer>().material = ourPaints[paintIndex];
            paintIndex = Random.Range(0, ListSize);
        }
    }
}
