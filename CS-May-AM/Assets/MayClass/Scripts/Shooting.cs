using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject prefab;
    public float shootingForce;
    public Transform SpawnPoint;
    public ShotCounter shotCounterScript;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject temp = Instantiate(prefab, SpawnPoint.position, SpawnPoint.rotation);
            temp.GetComponent<Rigidbody>().AddForce(temp.transform.forward * shootingForce);
            Destroy(temp, 3);
            shotCounterScript.shotsFired++;
        }
    }
}
