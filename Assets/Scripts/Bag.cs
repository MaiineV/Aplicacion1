using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : Item
{
    [SerializeField] private List<Item> items;

    public List<Item> GetItems() {  return items; }
}
