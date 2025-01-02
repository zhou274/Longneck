


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator CameraAnim;
    public GameObject Buildings;
    public GameObject mesh;
    public void Start()
    {
        mesh.SetActive(false);
        Buildings.SetActive(false);
    }
       public void OnTriggerEnter(Collider other)
    {
         if(other.tag=="stickmanbody")
         {
              Debug.Log("Rotate");
              CameraAnim.SetBool("isRotate",true);
              Buildings.SetActive(true);
              mesh.SetActive(true);
         }
    }
}
