using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerManager: MonoBehaviour
{
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
    public void PlaceTower(RaycastHit2D hit)
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
    }
}
