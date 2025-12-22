using System;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which to move between tiles
    public Tilemap walls;
    public Tilemap items;
    public TMP_Text coinCount;
    int coins = 1;

    private bool isMoving = false; // Is the object currently moving
    private Vector3Int currentTile; // Current tile position in tilemap coordinates
    private Vector3 targetPosition; // Target position to move towards


    void Start()
    {
        currentTile = walls.WorldToCell(transform.position);
        targetPosition = walls.GetCellCenterWorld(currentTile);
        transform.position = targetPosition;
    }

    void Update()
    {
        if(isMoving)
        {
            MoveTowardsTarget();
        }
        else
        {
            HandleInput();
        }
    }

    private void MoveTowardsTarget()
    {
        //move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            isMoving = false;
            PickUpCoins();
            DropCoin();
        }
    }

    private void PickUpCoins()
    {
        throw new NotImplementedException();
    }

    void DropCoin()
    {
        if (coins > 0)
        {
            coins--;
            UpdateUI();
        } else Die();
    }

    private void Die()
    {
        throw new NotImplementedException();
    }

    void UpdateUI()
    {
        coinCount.text = coins.ToString();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            AttemptMove(Vector3Int.up);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            AttemptMove(Vector3Int.down);
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            AttemptMove(Vector3Int.left);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            AttemptMove(Vector3Int.right);
        }
    }

    private void AttemptMove(Vector3Int direction)
    {
        //check if the target tile is walkable
        Vector3Int newTile = currentTile + direction;
        if (walls.GetTile(newTile) == null) // No wall tile means walkable
        {
            currentTile = newTile;
            targetPosition = walls.GetCellCenterWorld(currentTile);
            isMoving = true;
        }
    }
}
