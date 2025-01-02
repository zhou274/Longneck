


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    
       public Animator MeshAnim;
       public void OnTriggerEnter(Collider other)
    {
         if(other.tag=="stickmanbody")
         {
             MeshAnim.enabled=true;
         }
    }
}
