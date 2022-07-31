using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform weaponPoint, camTransform;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] float missDistance;
    [SerializeField] LayerMask mask;
    

    void Awake()
    {


    }
    public void Fire()
    {
        RaycastHit hit;

        GameObject bullet =  Instantiate(BulletPrefab, weaponPoint.position, weaponPoint.transform.rotation);
        MoveForward bulletController = bullet.GetComponent<MoveForward>();
        if(Physics.Raycast(camTransform.position, camTransform.forward, out hit, Mathf.Infinity, mask))
        {
            bulletController.target = hit.point;    
            bulletController.hit = true;
        } else 
        {
            bulletController.target = camTransform.position + camTransform.forward * missDistance;    
            bulletController.hit = false;
        }
        
    }
}


