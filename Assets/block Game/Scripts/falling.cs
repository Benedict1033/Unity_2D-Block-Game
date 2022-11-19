using System. Collections;
using System. Collections. Generic;
using UnityEngine;

public class falling : MonoBehaviour
{
    public Vector2 speedMinMax;

    float speed;
    float visibleWeightThreshold;

    private void Start ( )
    {
        visibleWeightThreshold=-Camera. main. orthographicSize-transform. lossyScale. y;
        speed=Mathf. Lerp ( speedMinMax. x, speedMinMax. y, Difficulty. GetDiffcultyPercent ( ) );
    }

    private void Update ( )
    {
        transform. Translate ( Vector3. down*speed*Time. deltaTime, Space. Self );


        if ( transform. position. y<visibleWeightThreshold )
        {
            Destroy ( gameObject );
        }
    }

    public void startGame ( )
    {
        UnityEngine. SceneManagement. SceneManager. LoadScene ( "Game" );
    }


}
