using UnityEngine;

namespace MainAssets.Scripts.ExtendMethod
{
    public static class ExtendRigidBody2d
    {
        public static void IsSimulate(this Rigidbody2D self, bool isSimulate)
        {
            self.simulated = isSimulate;
        }

        public static void ToKinematic(this Rigidbody2D self)
        {
            self.bodyType = RigidbodyType2D.Kinematic;
        }
        public static void ToDynamic(this Rigidbody2D self)
        {
            self.bodyType = RigidbodyType2D.Dynamic;
        }
        public static void ToStatic(this Rigidbody2D self)
        {
            self.bodyType = RigidbodyType2D.Static;
        }

        public static void ToVelocityZero(this Rigidbody2D self)
        {
            self.velocity=Vector2.zero;
        }
    }
}