using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    // Configruation Parameters
    [SerializeField] GameObject defender;

    public void OnMouseDown()
    {
        Vector2 whereClicked = GetSquareClicked();
        SpawnDefender(whereClicked);
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return worldPos;
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        GameObject newDefender = Instantiate(defender, worldPos, Quaternion.identity) as GameObject;
    }
}
