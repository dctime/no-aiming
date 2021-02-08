using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirectorActivePlayerHandler : MonoBehaviour
{
    private SelectedCharacterOutputHandler output;

    private string player1Character;
    private string player2Character;

    [Header("雙方角色母群體")]
    [SerializeField] private GameObject player1Group;
    [SerializeField] private GameObject player2Group;

    public void ActivePlayer(string player1Character, string player2Character)
    {
        for (int i = 0; i < player1Group.transform.childCount; i++)
        {
            if (player1Group.transform.GetChild(i).gameObject.name == player1Character)
            {
                player1Group.transform.GetChild(i).gameObject.SetActive(true);
                break;
            }
        }

        for (int i = 0; i < player2Group.transform.childCount; i++)
        {
            if (player2Group.transform.GetChild(i).gameObject.name == player2Character)
            {
                player2Group.transform.GetChild(i).gameObject.SetActive(true);
                break;
            }
        }
    }
    private void Awake()
    {
        output = FindObjectOfType<SelectedCharacterOutputHandler>();

        player1Character = output.player1CharacterGetter();
        player2Character = output.player2CharacterGetter();

        ActivePlayer(player1Character, player2Character);
    }

    private void Start()
    {
        Destroy(output.gameObject);
    }

}
