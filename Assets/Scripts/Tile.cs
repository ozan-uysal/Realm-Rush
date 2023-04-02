
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


    [SerializeField] bool isPlaceable;
    public bool IsPlaceable {  get {return isPlaceable; } }

    MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        material = meshRenderer.sharedMaterial;      
    }
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
