using Assets.Scripts.Move;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Assets.Scripts.Object
{
    //背景オブジェクトなど動くプレハブにアタッチされるクラス。
    public class MovePrefab :MoveObject
    {
        private float addRandomPosition;
        public float limitTeleportPosition;
        public float maxAddRandomPosition;
        public float minTransformPosition;
        private Transform nowPosition;

        protected override void Start()
        {
            base.Start();
            Move();
        }

        private void FixedUpdate()
        {
            nowPosition= this.transform;
            if (!DoTeleport()) return;
            TeleportPrefab();
        }
        //規定した位置に移動したら瞬間移動するか調べる
        private bool DoTeleport()
        {
            return this.transform.localPosition.x <= limitTeleportPosition;
        }
        
        //画面外に行ったら場所を元に戻すなどに利用する。
        private void TeleportPrefab()
        {
            addRandomPosition=Random.Range(0,maxAddRandomPosition);
            var localPosition = nowPosition.localPosition;
            localPosition= new Vector3(localPosition.x+minTransformPosition + addRandomPosition , localPosition.y, localPosition.z);
            nowPosition.localPosition = localPosition;
        }
    }
}
