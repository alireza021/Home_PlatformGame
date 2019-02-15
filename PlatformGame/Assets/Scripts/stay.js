#pragma strict

  function OnTriggerStay(other:Collider){
             
             if(other.gameObject.tag == "platform"){
             transform.parent = other.transform;
 
         }
     }
 
 function OnTriggerExit(other:Collider){
     if(other.gameObject.tag == "platform"){
             transform.parent = null;
             
         }
     }    