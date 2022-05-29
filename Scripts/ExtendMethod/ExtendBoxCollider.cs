using UnityEngine;

namespace MainAssets.Scripts.ExtendMethod
{
	public static class ExtendBoxCollider
	{ 
		/// <summary>
		/// BoxColliderの半径を取得する
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static Vector2 GetRadius(this BoxCollider2D self)
		{
			return self.size / 2;
		}
	}
}
