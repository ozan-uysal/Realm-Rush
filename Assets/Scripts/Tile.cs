
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    public Material placeableMaterial;
    public Material nonPlaceableMaterial;
    Material material;
    bool isPlaced;

    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();


    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }

    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        material = meshRenderer.sharedMaterial;

        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
            if(!isPlaceable) 
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable {  get {return isPlaceable; } }

    MeshRenderer meshRenderer;

    private void OnMouseDown()
    {  
        if (isPlaceable)
        {
            isPlaced = towerPrefab.CreateTower(towerPrefab,transform.position);
            isPlaceable = !isPlaced;
        }
    }
    private void OnMouseOver()
    {
            meshRenderer.sharedMaterial = IsPlaceable ? placeableMaterial : nonPlaceableMaterial;
    }
    private void OnMouseExit()
    {
        meshRenderer.sharedMaterial = material;
    }

}
