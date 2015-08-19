Using UnityEngine;
Using System.Collections;

Void Update () { 
  if (Input.GetKey(KeyCode.W)) {
     Transform.position = Vector3.forward;
   
     if (Input.GetKey(KeyCode.S)) {
        Transform.position = -Vector3.forward;
 
        if (Input.GetKey(KeyCode.D)) {
            Transform.position = Vector3.right;

            if (Input.GetKey(KeyCode.A)) {
                Transform.position = -Vector3.right;
          }
        }
      }
    }
  }
    
