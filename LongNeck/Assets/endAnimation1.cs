


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endAnimation1 : MonoBehaviour
{
    // Start is called before the first frame update
        public void OnTriggerEnter(Collider other)
    {
         if(other.tag=="stickmanbody" || other.tag=="head" || other.tag=="ring")
         {
           playerMove._playerMove.Finish_x1_1_Anim.enabled=true;
            // playerMove._playerMove._PlayerPos=1;
            playerMove._playerMove.HeightCountTxt.text="X1.1";
            // playerMove._playerMove.TotalHeightTxt.text="7.3";
           
           Debug.Log("enter");
         }
    }

}
