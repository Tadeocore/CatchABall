using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallBounce : MonoBehaviour
{


    /*
     * Estuve viendo como funciona la specular de las luces, basicamente, agarra la luz, la refleja contra una superficie
     * y eso hace que se "refleje" hacia el angulo de la camara. En base a eso, estoy tratando de hacer el bounce
     * de las pelotas o bolas de cañon o misiles, lo que sea que vaya a tener nuestro juego.
     * 
     * Voy a tratar de comentar bien todo asi se entiende el codigo 
     */
    public int maxReflectionCount = 5;
    public float maxStepDistance = 200f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.ArrowHandleCap(0, this.transform.position + this.transform.forward * 0.25f, this.transform.rotation, 0.5f, EventType.Repaint);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, 0.25f);

        DrawPredictedReflectionPattern(this.transform.position + this.transform.forward * 0.75f, this.transform.forward, maxReflectionCount);
    }
    private void DrawPredictedReflectionPattern(Vector3 position, Vector3 direction, int reflectionsRemaining)
    {
        if (reflectionsRemaining == 0){
            return;
        }
        Vector3 startingPosition = position;
        //Aca se viene el raycast

        Ray ray = new Ray(position, direction);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, maxStepDistance))
        {
            direction = Vector3.Reflect(direction, hit.normal);
            position = hit.point;

        }
        else
        {
            position += direction * maxStepDistance;
        }
       
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(startingPosition, position);

        DrawPredictedReflectionPattern(position + direction * maxStepDistance, direction, reflectionsRemaining - 1);
    }
}
