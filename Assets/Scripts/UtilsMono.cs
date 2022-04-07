using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
    
public class UtilsMono : MonoBehaviour {
    static public UtilsMono instance;
    void Awake(){
        instance = this;
    }
    public static IEnumerator couroutineSequenceWithPause(List<IEnumerator> routines, float pause, bool canContinue) {
        foreach (IEnumerator routine in routines) {
            yield return instance.StartCoroutine(routine);
            float elapsedTime = 0;
            while (elapsedTime < pause)
            {
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
        canContinue = true;
        yield return null;
    }

    public static IEnumerator WaitXSecondsWrapper(int x) {
        yield return Utils.StaticUtils.waitXSeconds(x);
    }

    public static IEnumerator MoveOverSecondsWrapper(Transform objectToMove, Vector3 end, float seconds) {
        yield return Utils.StaticUtils.MoveOverSeconds(objectToMove, end, seconds);
    }
    public static IEnumerator MoveObjXYOverSeconds(Transform objectToMove, float deltaX, float deltaY, float seconds) {
        Vector3 end = new Vector3(objectToMove.position.x + deltaX, objectToMove.position.y + deltaY, objectToMove.position.z);
        yield return Utils.StaticUtils.MoveOverSeconds(objectToMove, end, seconds);
    }

    private static IEnumerator MoveOverSpeedWrapper(Transform objectToMove, Vector3 end, float speed) { 
        yield return Utils.StaticUtils.MoveOverSpeed(objectToMove, end, speed);
    }
}
