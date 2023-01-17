using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class FollowTransform : MonoBehaviour {

        public Transform FollowTarget;
        public bool MatchRotation = true;

        void Update() {
            if(FollowTarget) {
                transform.position = FollowTarget.position;

                if(MatchRotation) {
                    transform.eulerAngles = new Vector3(0, FollowTarget.rotation.eulerAngles.y, 0);
                }
            }
        }
    }
