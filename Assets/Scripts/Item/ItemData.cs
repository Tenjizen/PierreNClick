using System;
using UnityEngine;

[Serializable]
public class ItemData 
{
    public enum ItemDropable { Chisel, Paint, Paper, Pen };
    public ItemDropable DataItemDrop;
    public string DataID;
    public string DataName;
    public Sprite DataSprite;
}