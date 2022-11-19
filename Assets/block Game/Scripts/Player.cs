using System. Collections;
using System. Collections. Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    float screenHalfWidthInEorldUnits ;

    public event System.Action OnPlayerDeath;

    bool left;
    bool right;

    private void Start ( )
    {
        float halfplayerwidth = transform.localScale.x/2;
        screenHalfWidthInEorldUnits=Camera. main. aspect*Camera. main. orthographicSize-halfplayerwidth;

    }

    private void Update ( )
    {
        //float inputx = Input. GetAxisRaw ( "Horizontal" );
        //float velocity = inputx*speed;
        //transform. Translate ( Vector2. right*velocity*Time. deltaTime );

        if ( Input. GetKey ( KeyCode. A ) )
        {
            Vector3 xinput=new Vector3(-1,0,0);
            Vector3 xdirection = xinput.normalized;
            Vector3 xvelocity =xdirection*speed;
            Vector3 xmoveAmount = xvelocity*Time.deltaTime;
            transform. Translate ( xmoveAmount );
        }
        if ( Input. GetKey ( KeyCode. D ) )
        {
            Vector3 xinput=new Vector3(1,0,0);
            Vector3 xdirection = xinput.normalized;
            Vector3 xvelocity =xdirection*speed;
            Vector3 xmoveAmount = xvelocity*Time.deltaTime;
            transform. Translate ( xmoveAmount );
        }

        if ( transform. position. x<-screenHalfWidthInEorldUnits )
        {
            transform. position=new Vector2 ( screenHalfWidthInEorldUnits, transform. position. y );
        }
        if ( transform. position. x>screenHalfWidthInEorldUnits )
        {
            transform. position=new Vector2 ( -screenHalfWidthInEorldUnits, transform. position. y );
        }



        if ( left )
        {
            Vector3 xinput=new Vector3(-1,0,0);
            Vector3 xdirection = xinput.normalized;
            Vector3 xvelocity =xdirection*speed;
            Vector3 xmoveAmount = xvelocity*Time.deltaTime;
            transform. Translate ( xmoveAmount );
        }
        if ( right)
        {
            Vector3 xinput=new Vector3(1,0,0);
            Vector3 xdirection = xinput.normalized;
            Vector3 xvelocity =xdirection*speed;
            Vector3 xmoveAmount = xvelocity*Time.deltaTime;
            transform. Translate ( xmoveAmount );
        }
    }

    private void OnTriggerEnter ( Collider other )
    {
        if ( other. tag=="Block" )
        {
            if ( OnPlayerDeath!=null )
            {
                OnPlayerDeath ( );
            }

            Destroy ( gameObject );
        }
    }

//using hold button

    public void Left ( )
    {
        left=true;
    }

    public void Right ( )
    {
        right=true;
    }
    
    public void Leftstop ( )
    {
        left=false;
    }

    public void Rightstop ( )
    {
        right=false;
    }

}
