using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
   public PathCreator pathCreator;
   public EndOfPathInstruction end;
   public float speed;
   float dstTravelled;
   public bool pathFollowEnabled;

   private void FixedUpdate() {
        if (pathFollowEnabled) {
            dstTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(dstTravelled, end);
            transform.rotation = pathCreator.path.GetRotationAtDistance(dstTravelled);
        }
        if (transform.position == pathCreator.path.GetPoint(pathCreator.path.NumPoints - 1)) {
            pathFollowEnabled = false;
        }
   }
}
