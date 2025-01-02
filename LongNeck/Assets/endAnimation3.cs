


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endAnimation3 : MonoBehaviour
{
    // Start is called before the first frame update
        public void OnTriggerEnter(Collider other)
    {
         if(other.tag=="stickmanbody" || other.tag=="head" || other.tag=="ring")
         {
           playerMove._playerMove.Finish_x1_3_Anim.enabled=true;
           
              playerMove._playerMove.HeightCountTxt.text="X1.3";
           
          
           Debug.Log("enter");
         }
    }

}
