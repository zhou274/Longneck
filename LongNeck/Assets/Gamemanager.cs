


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public GameObject[] Levels;
    public GameObject road;
    public int LevelNumber,LevelNumber_D,diamond;
     public TextMeshProUGUI LevelNumTxt,LevelFailNumTxt,DiamondTxt;
    // Start is called before the first frame update

    public static Gamemanager _Gamemanager;
    void Awake()
    {
      _Gamemanager=this;
    }
    void Start()
    {
    //      if(PlayerPrefs.GetInt("LevelNum",0)==1)
    //   {
    //     PlayerPrefs.SetInt("LevelNum",0);
       
    //   }
      if(PlayerPrefs.GetInt("LevelNum_D",0)==0)
        {
          PlayerPrefs.SetInt("LevelNum_D",1);
        }
       LevelNumber_D=PlayerPrefs.GetInt("LevelNum_D");
      LevelNumber=PlayerPrefs.GetInt("LevelNum");
      Levels[LevelNumber].SetActive(true);
      LevelNumTxt.text = "µ±Ç°¹Ø¿¨ " + LevelNumber_D.ToString("");
      LevelFailNumTxt.text = LevelNumber_D.ToString("");
        Debug.Log("LevelNumber "+LevelNumber);
      if(LevelNumber==0)
      {
        road.SetActive(false);
      }
      else
      {
        road.SetActive(true);
      }
      
       
    }

    // Update is called once per frame
    void Update()
    {
        DiamondTxt.text=PlayerPrefs.GetInt("Diamond").ToString("");
    }
}
