using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Utils {

    public static class StaticUtils {

        public static IEnumerator waitXSeconds(int x) {
            float elapsedTime = 0;
            while (elapsedTime < x)
            {
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            yield return null;
        }
        public static IEnumerator MoveOverSeconds(Transform objectToMove, Vector3 end, float seconds)
        {
            float elapsedTime = 0;
            Vector3 startingPos = objectToMove.transform.position;
            while (elapsedTime < seconds)
            {
                objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            objectToMove.transform.position = end;
        }

        public static IEnumerator MoveOverSpeed(Transform objectToMove, Vector3 end, float speed){
            // speed should be 1 unit per second
            while (objectToMove.transform.position != end)
            {
                objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame ();
            }
        }

        public static void verticalInputMovement(GameObject obj, float speed) {
            float h = 0;
            float v = -1 * Input.GetAxisRaw("Vertical");
            Vector3 tempVect = new Vector3(h, v, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            obj.transform.position += tempVect;
        }

        public static void verticalMouseMovement(GameObject obj, float speed) {
            Vector3 newVector = new Vector3(
                    obj.transform.position.x, 
                    obj.transform.position.y * Input.GetAxis("Mouse ScrollWheel"), 
                    0
            );
            obj.transform.Translate(newVector);
        }
    }
}