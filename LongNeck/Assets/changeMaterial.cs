


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMaterial : MonoBehaviour
{
    // Start is called before the first frame update
    public Material _material;
       
  
  public static changeMaterial _changeMaterial;
       public void OnTriggerEnter(Collider other)
    {
         if(other.tag=="stickmanbody")
         {
              foreach(Transform t in playerMove._playerMove.PlayerHeadTop.transform)
           {
               t.GetComponent<MeshRenderer>().material = _material;
            //    childObjects.Add(t.gameObject);
        }
            foreach(Transform t in playerMove._playerMove.PlayerHead.transform)
           {
               t.GetComponent<MeshRenderer>().material = _material;
        }
              playerMove._playerMove.PlayerBody.GetComponent<SkinnedMeshRenderer>().material=_material;
         }
        
}
}
