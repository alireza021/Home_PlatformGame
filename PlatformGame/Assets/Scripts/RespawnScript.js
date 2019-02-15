var spawnPoint : Transform; 


 function OnTriggerEnter(other : Collider)
 {
     if (other.gameObject.tag == "Player")
     {
         other.transform.position = spawnPoint.position;
       
     }
 }