using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionSphereBehaviour : MonoBehaviour
{
    [SerializeField] List<GameObject> tileList = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tile"))
        {
            tileList.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Tile"))
        {
            tileList.Remove(other.gameObject);
        }
    }

    public void DestroyTiles()
    {
        foreach (GameObject tile in tileList)
        {
            tile.gameObject.GetComponent<TileParentCaller>().CallParentDestroyTileFunction();
        }
        tileList.Clear();
    }
}
