using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Item> actualItems;
    private Stack<Item> stack;

    public void Interact(Player player)
    {
        player.AddItems(SearchItems(actualItems));
    }

    private List<Item> SearchItems(List<Item> items)
    {
        var actualList = new List<Item>();
        foreach (Item item in items)
        {
            if (item is Bag)
            {
                var bag = item as Bag;

                actualList.AddRange(SearchItems(bag.GetItems()));
            }
            else
            {
                actualList.Add(item);
            }
        }
        return actualList;
    }
}
