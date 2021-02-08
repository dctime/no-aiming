using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SelectCharacterController : MonoBehaviour
{
    [Header("角色群體")]
    [SerializeField] private GameObject characterGroup;
    
    //角色陣列
    private GameObject[] characters;

    //現在顯示在螢幕上的角色物件和索引
    private GameObject currentCharacter;
    private int currentIndex;

    [Header("按鍵設定")]
    [SerializeField] private KeyCode nextKey;
    [SerializeField] private KeyCode previousKey;

    private void Start()
    {
        //將角色群體的角色搬到characters陣列裡
        characters = new GameObject[characterGroup.transform.childCount];

        for (int i = 0; i < characterGroup.transform.childCount; i++)
        {
            characters[i] = characterGroup.transform.GetChild(i).gameObject;
        }
        
        //將角色陣列的第一個角色設為目前顯示在場景上的角色
        currentIndex = 0;
        currentCharacter = characters[currentIndex];
        characters[0].SetActive(true);
    }

    private void Update()
    {
        //如果按下會切換成下一個角色的按鈕
        if (Input.GetKeyDown(nextKey))
        {
            //目前索引加一
            currentIndex += 1;
            
            //如果目前索引已大於此陣列最大索引
            if (currentIndex + 1 > characters.Length)
            {
                //將其歸零
                currentIndex = 0;
            }

            //將原本的角色關掉
            currentCharacter.SetActive(false);
            //將下一個角色的物件存入currentCharacter
            currentCharacter = characters[currentIndex];
            //將下一個物件激活
            currentCharacter.SetActive(true);
            //將下一個物件的位置歸零
            currentCharacter.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (Input.GetKeyDown(previousKey)) //如果按下會切換成上一個角色的按鈕
        {
            //目前索引減一
            currentIndex -= 1;

            //如果目前索引小於零
            if (currentIndex < 0)
            {
                //將其設為最大值
                currentIndex = characters.Length - 1;
            }

            //將原本的角色關掉
            currentCharacter.SetActive(false);
            //將上一個角色的物件存入currentCharacter
            currentCharacter = characters[currentIndex];
            //將上一個物件激活
            currentCharacter.SetActive(true);
            //將上一個物件的位置歸零
            currentCharacter.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
