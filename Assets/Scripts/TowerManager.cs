using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;



public class TowerManager: MonoBehaviour
{/*
    TowerBnt towerBtnPressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);// lets us see that a button was clicked 
            RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);// Lets us get information on what it hits or where tower will be placed
            PlaceTower(hit);

        }
    }
    //public void PlaceTower(RaycastHit2D hit)
    {
        if(!EventSystem.current.IsPointerOverGameObject() && towerBtnPressed !=null )
        {
            GameObject newTower = Instantiate(towerBtnPressed.TowerObject);
            newTower.transform.position = hit.transform.position;
        }
      
    }
    public void SelectedTower(TowerBnt towerSelected)// Lets me select the button and chosse a tower
    {
        towerBtnPressed = towerSelected;
        Debug.Log("Pressed" + towerBtnPressed.gameObject);
    }*/
    // list to spawn towers 
    public List<GameObject> Towers;
    // transform To spawn towers 
    public Transform spawnTowerRoot;
    // id of Tower to spawn 
    int spawnID = -1 ;
    // Invisible floor 
    public Tilemap InvisibleFloor;

    // Basic UI List to make ui highlight
    public List<Image> towerUI;

    void Update()
    {
        if (WillSpawn())
        DetectInvisibleFloor();
    }
    bool WillSpawn()
    {
        if (spawnID == -1)
            return false;
        else return true;
    }

    void DetectInvisibleFloor()
    {
        if(Input.GetMouseButtonDown(0))
        { 
        //Get Pos of mouse
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Get Pos of Cell In tile Map 
       var cellPosDefualt =InvisibleFloor.WorldToCell(mousePos);

            // Get Center Pos Of cell
            var cellPosCenter = InvisibleFloor.GetCellCenterWorld(cellPosDefualt);
        // Check if we can spawn there 
        if(InvisibleFloor.GetColliderType(cellPosDefualt)== Tile.ColliderType.Sprite)
            {
                //Spawn tower
                SpawnTower(cellPosCenter);
            //Disable the collider on the tiles  
                InvisibleFloor.SetColliderType(cellPosDefualt, Tile.ColliderType.None);
            }
           

        // if yes spawn and disable Colider
        // if No do Nada Zero zip Nothing
        
        }
    }
    void SpawnTower(Vector3 position)
    {
        GameObject tower = Instantiate(Towers[spawnID],spawnTowerRoot);
        tower.transform.position = position;
        DeselectTower();
    }
    public void SelectTower(int id)
    {
        DeselectTower();
        spawnID = id;
        //Highlight the Tower
        towerUI[spawnID].color = Color.white;
    }

    public void DeselectTower()
    {
        spawnID = -1;

        foreach(var t in towerUI)
        {
            t.color = new Color(.5f, .5f, .5f);
        }

    }
        
    }















































