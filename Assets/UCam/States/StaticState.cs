using System.Collections;
using UCAM.Modules;
using UnityEngine;

namespace UCAM.States
{
    public class StaticState : CameraStateBase
    {
        [SerializeField] private float moveToPointDuration = .5f;
        [SerializeField] private Vector3 cameraPointOnMovingToPoint = new Vector3(0, 0, -100);

        private LimitModule limitModule;

        public override void Enter()
        {
            base.Enter();
            limitModule = owner.GetModule<LimitModule>();
            limitModule.DoActivate();
        }

        public override void Exit()
        {
            base.Exit();
            limitModule.DoDeactivate();
        }

        public void GoTo(Vector3 destination)
        {
            //SetEnable(false);
            destination = limitModule.Apply(destination);
            owner.StartCoroutine(MovingCamera(destination));
        }
        private IEnumerator MovingCamera(Vector3 destination)
        {
            Vector3 startPos = owner.Tr.position;
            Vector3 camStartPos = owner.CamTr.localPosition;
            Vector3 destinationPos = new Vector3(destination.x, startPos.y, destination.z);

            float startTime = Time.time;
            float progress = 0;
            while (Time.time - startTime < moveToPointDuration)
            {
                progress = (Time.time - startTime) / moveToPointDuration;
                owner.Tr.position = Vector3.Lerp(startPos, destinationPos, progress);
                owner.CamTr.localPosition = Vector3.Lerp(camStartPos, cameraPointOnMovingToPoint, progress);
                yield return new WaitForEndOfFrame();
            }

            owner.Tr.position = destinationPos;
        }
    }
}
