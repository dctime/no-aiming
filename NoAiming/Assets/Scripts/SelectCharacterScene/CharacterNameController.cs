using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterNameController : MonoBehaviour
{
    [Header("角色群體")]
    [SerializeField] GameObject characterGroup;

    [Header("目標文字")]
    [SerializeField] Text text;

    private void Update()
    {
        for (int i = 0; i < characterGroup.transform.childCount; i++)
        {
            if (characterGroup.transform.GetChild(i).gameObject.activeSelf == true)
            {
                text.text = characterGroup.transform.GetChild(i).gameObject.name;
                break;
            }
        }
        
    }
}
