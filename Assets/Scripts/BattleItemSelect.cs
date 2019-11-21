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
        BattleManager.instance.itemMenu.SetActive(false);
        BattleManager.instance.OpenPlayerTargetMenu(itemName);
    }
}
