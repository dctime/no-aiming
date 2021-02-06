using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SelectCharacterController : MonoBehaviour
{
    private enum Character
    {
        PewPewGunner,
        Sniper
    }

    Character_Linked_Array characters;

    class Node
    {

        private Character character;
        private Node next;
        private Node previous;

        public Node(Character character)
        {
            this.character = character;
        }

        public Node Next_Getter()
        {
            return next;
        }
        public void Next_Setter(Node next_node)
        {
            this.next = next_node;
        }
        public Node Previous_Getter()
        {
            return previous;
        }
        public void Previous_Setter(Node previous_node)
        {
            previous = previous_node;
        }
        public Character Character_Getter()
        {
            return character;
        }

    }

    class Character_Linked_Array
    {
        //儲存此鏈結串列的開頭節點
        private Node head;
        private Node end;

        //添加一個新節點
        public void Add_Node(Node node)
        {
            //如果這個鏈結陣列沒有頭
            if (head == null)
            {
                head = node;
                end = node;
            }
            else //如果這個鏈結陣列有頭
            {
                end.Next_Setter(node);
                node.Previous_Setter(end);
                end = node;
            }

        }

        public void PrintArray()
        {
            Node nowPrinting;

            nowPrinting = head;

            while (true)
            {
                if (nowPrinting == null)
                {
                    Debug.Log("No more");
                    break;
                }
                else
                {
                    Debug.Log(nowPrinting.Character_Getter());
                    nowPrinting = nowPrinting.Next_Getter();
                }
            }
        }
    }

    private void Start()
    {
        //做一個Node, 存放PewPewGunner的資料
        Node pewPewGunner = new Node(Character.PewPewGunner);
        Node sniper = new Node(Character.Sniper);

        characters = new Character_Linked_Array();

        characters.Add_Node(pewPewGunner);
        characters.Add_Node(sniper);
        characters.PrintArray();
    }
}
