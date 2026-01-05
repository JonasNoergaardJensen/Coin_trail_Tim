using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tiles/ItemTile")]
public class ItemTile : Tile
{
    public enum ItemType { Coin}
    public ItemType itemType;
    public int amount = 1;
}