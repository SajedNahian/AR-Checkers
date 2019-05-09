using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vuforia {
    public class ImageTargetInterfaceHandler : MonoBehaviour 
    {
        private TrackableBehaviour mTrackableBehaviour;
        private static GameObject scanPrompt;
        void Start()
        {
            scanPrompt = GameObject.FindGameObjectWithTag("ScanPrompt");
            //mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            //if (mTrackableBehaviour)
            //{
            //    mTrackableBehaviour.RegisterTrackableEventHandler(this);
            //}
        }

        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                scanPrompt.SetActive(false);
            }
            else
            {
                scanPrompt.SetActive(true);
            }
        }

        public static void DisableScanPrompt()
        {
            scanPrompt.SetActive(false);
        }

        public static void EnableScanPrompt()
        {
            scanPrompt.SetActive(true);
        }
    }
}