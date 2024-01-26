using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
   public Transform player;

   private void FollowPlayer()
   {
      transform.position = player.position;
   }
}
