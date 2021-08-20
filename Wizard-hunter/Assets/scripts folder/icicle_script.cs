using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icicle_script : MonoBehaviour
{
    [SerializeField] private LayerMask thickPlatformLayerMask;
    [SerializeField] private float selfDestructTimer;
    private bool directionSet = false;
    private float velocityX = 0f;
    private float velocityY = 0f;
    private float IceSpeed = 0f;
    private float selfDestruct = 10f;
    private BoxCollider2D boxCollider;
    private Animator ani;



    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        ani = GetComponent<Animator>();
        selfDestruct = selfDestructTimer;
    }

    // Update is called once per frame
    void Update()
    {

        Collider2D collidedPlatform = Physics2D.OverlapBox(boxCollider.bounds.center, boxCollider.bounds.size, 0f, thickPlatformLayerMask);//checks if the Ice has hit a thickPlatform

        //kills itself after x seconds (determined by selfDestructTimer)
        selfDestruct = selfDestruct - Time.deltaTime;
        if (selfDestruct <= 0)
        {
            Destroy(gameObject);
            
        }


        if (collidedPlatform != null)
        {
            //ani.SetTrigger("explode");
            Destroy(gameObject, 0.5f);
            

        }
        else
        {
            if (directionSet == true)
            {
                transform.position = transform.position + new Vector3(Time.deltaTime * velocityX * IceSpeed, Time.deltaTime * velocityY * IceSpeed, 0);//moves Ice to new spot every frame based on the passed IceSpeed and direction
            }

        }
    }

    public void setIceDirection(float velX, float velY, float speed)
    {
        velocityX = velX;
        velocityY = velY;
        IceSpeed = speed;
        directionSet = true;
    }
}
