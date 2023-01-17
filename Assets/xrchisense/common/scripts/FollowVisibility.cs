using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class FollowVisibility : MonoBehaviour {

        public GameObject FollowTarget;
       

        void Update() {
            if(FollowTarget) {
                this.gameObject.SetActive(FollowTarget.activeSelf);

            }
        }
    }
