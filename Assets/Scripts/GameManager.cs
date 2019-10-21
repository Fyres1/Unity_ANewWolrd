using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public CharStats[] playerStats;

    public bool gameMenuOpen, dialogActive, fadingBetweenAreas;

    public string[] itemHeld;
    public int[] numberOfItems;
    public Item[] referenceItems;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //stop player from moving during load, open menu or during dialogs with npcs
        if(gameMenuOpen || dialogActive || fadingBetweenAreas)
        {
            PlayerController.instance.canMove = false;
        }
        else
        {
            PlayerController.instance.canMove = true;
        }
        //test to add/remove item in item menu by pressing J
        if (Input.GetKeyDown(KeyCode.J))
        {
            AddItem("Iron Armor");
            AddItem("Blabla");

            RemoveItem("Health Potion");
            RemoveItem("Bleep");
        }
    }

    public Item GetItemDetails(string itemToGrab)
    {
        for(int i = 0; i < referenceItems.Length; i++)
        {
            if(referenceItems[i].itemName == itemToGrab)
            {
                return referenceItems[i];
            }
        }





        return null;
    }

    // sort items at the beginning of the array
    public void SortItems()
    {
        bool itemAfterSpace = true;

        while (itemAfterSpace)
        {
            itemAfterSpace = false;
            for (int i = 0; i < itemHeld.Length - 1; i++)
            {
                if (itemHeld[i] == "")
                {
                    itemHeld[i] = itemHeld[i + 1];
                    itemHeld[i + 1] = "";

                    numberOfItems[i] = numberOfItems[i + 1];
                    numberOfItems[i + 1] = 0;

                    if(itemHeld[i] != "")
                    {
                        itemAfterSpace = true;
                    }
                }
            }
        }
    }

    public void AddItem(string itemToAdd)
    {
        int newItemPosition = 0;
        bool foundSpace = false;

        for(int i = 0; i < itemHeld.Length; i++)
        {
            if(itemHeld[i] == "" || itemHeld[i] == itemToAdd)
            {
                newItemPosition = i;
                i = itemHeld.Length;
                foundSpace = true;
            }
        }

        if (foundSpace)
        {
            bool itemExists = false;
            for(int i = 0; i < referenceItems.Length; i++)
            {
                if(referenceItems[i].itemName == itemToAdd)
                {
                    itemExists = true;

                    i = referenceItems.Length;
                }
            }

            if (itemExists)
            {
                itemHeld[newItemPosition] = itemToAdd;
                numberOfItems[newItemPosition]++;
            }
            else
            {
                Debug.LogError(itemToAdd + " Does Not Exist!!");
            }
        }

        GameMenu.instance.ShowItems();
    }

    public void RemoveItem(string itemToRemove)
    {
        bool foundItem = false;
        int itemPosition = 0;

        for(int i = 0; i < itemHeld.Length; i++)
        {
            if(itemHeld[i] == itemToRemove)
            {
                foundItem = true;
                itemPosition = i;

                i = itemHeld.Length;
            }
        }

        if (foundItem)
        {
            numberOfItems[itemPosition]--;

            if(numberOfItems[itemPosition] <= 0)
            {
                itemHeld[itemPosition] = "";
            }

            GameMenu.instance.ShowItems();
        }
        else
        {
            Debug.LogError("Couldn't find " + itemToRemove);
        }
    }
}
