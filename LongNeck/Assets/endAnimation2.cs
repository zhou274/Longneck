


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endAnimation2 : MonoBehaviour
{
    // Start is called before the first frame update
        public void OnTriggerEnter(Collider other)
    {
         if(other.tag=="stickmanbody" || other.tag=="head" || other.tag=="ring")
         {
           playerMove._playerMove.Finish_x1_2_Anim.enabled=true;
           
              playerMove._playerMove.HeightCountTxt.text="X1.2";
              // if(playerMove._playerMove.childcount>30)
              // {
                //  playerMove._playerMove._PlayerPos=3;
                //  playerMove._playerMove.TotalHeightTxt.text="9.2";
              // }
              //  if(playerMove._playerMove.childcount>40)
              // {
                //  playerMove._playerMove._PlayerPos=4;
                //  playerMove._playerMove.TotalHeightTxt.text="11.5";
              // }
              //  if(playerMove._playerMove.childcount>50)
              // {
                //  playerMove._playerMove._PlayerPos=5;
                //  playerMove._playerMove.TotalHeightTxt.text="15";
              // }
              // else
              // {
                //  playerMove._playerMove._PlayerPos=2;
                  // playerMove._playerMove.TotalHeightTxt.text="7.8";
              // }
             
           Debug.Log("enter");
         }
    }

}
