using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleItemSelect : MonoBehaviour
{

    public string itemName;
    public int itemHeld;
    public Text nameText;
    public Text numberText;
    public int buttonValue;
    public int amountToChange;

    public int activeBattlerTarget;
    public Text targetName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Press()
    {
        if (BattleManager.instance.itemMenu.activeInHierarchy)
        {
            BattleManager.instance.SelectUseItem(GameManager.instance.GetItemDetails(GameManager.instance.itemHeld[buttonValue]));
            BattleManager.instance.itemMenu.SetActive(false);
            BattleManager.instance.OpenPlayerTargetMenu(itemName);
            
            //BattleManager.instance.HealItem(itemName, activeBattlerTarget);
        }
    }
}
