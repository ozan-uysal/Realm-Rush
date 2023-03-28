using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor= Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f,0.5f,0f);
    
    Node node;

    TextMeshPro label;
    Vector2Int coordinates= new Vector2Int();
    
    GridManager gridManager;
    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        
        label = GetComponent<TextMeshPro>();
        label.enabled = true;
        
        DisplayCordinates();
        UpdateObjectName();
    }
    void Update()
    {
        if (Application.isPlaying)
        {
            DisplayCordinates();
            UpdateObjectName();
        }
        SetLabelColor();
        ToggleLabels();
        //Debug.Log(gridManager, gridManager);
    }
    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }
    void SetLabelColor()
    {
        if (gridManager == null) { return;}

        node = gridManager.GetNode(coordinates);

        if (node == null) { return; }
       
        if (!node.isWalkable)
        {
            label.color = blockedColor;
        }
        else if (node.isPath)
        {
            label.color = pathColor;
        }
        else if (node.isExplored)
        {
            label.color = exploredColor;
        }
        else
        {
            label.color = defaultColor;
        }
    }
    void DisplayCordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x/10);//WARNING yapay zeka ile ilgili hata oluþabilir.
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z/10);//WARNING yapay zeka ile ilgili hata oluþabilir.
        label.text = coordinates.x + "," + coordinates.y;
    }
    void UpdateObjectName()
    {
        transform.parent.name=coordinates.ToString();
    }
}
