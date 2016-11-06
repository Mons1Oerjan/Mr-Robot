 using UnityEngine;
 using System.Collections;
 
 public class moveObjectVertically : MonoBehaviour {
 
     public float delta = 1.5f;  // Amount to move left and right from the start point
     public float speed = 2.0f; 
     private Vector3 startPos;
 
     void Start () {
         startPos = transform.position;
     }
     
     void Update () {
         Vector3 v = startPos;
         v.y += delta * Mathf.Sin (Time.time * speed);
         transform.position = v;
     }

     void OnTriggerStay(Collider c)
     {
         if (c.transform.tag == "Player")
         {
            transform.parent = c.transform;
             
         }
     }
 
     void OnTriggerExit(Collider c)
     {
         if (c.transform.tag == "Player")
         {
             transform.parent = null;
         }
     }
 }