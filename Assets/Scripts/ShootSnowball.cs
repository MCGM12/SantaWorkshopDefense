using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSnowball : MonoBehaviour
{
    public Transform SnowBallShooter;

    public SnowballTower tower;

    private void Update()
    {
        if (tower != null)
        {
            if (tower.currentTarget != null)
            {
                Vector2 relative = tower.currentTarget.transform.position;

                float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
            }
        }
    }
}
