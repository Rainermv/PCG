using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.PDev.PCG
{
	public class EntityFactory
	{

		#region public proprieties

		public static EntityFactory Instance {
			get {
				if (instance == null) {
					instance = new EntityFactory ();
				}
				return instance;
			}
		}

		#endregion

		#region private variables

		static public EntityFactory instance;

		#endregion

		#region private methods

		private EntityFactory ()
		{
		}

		#endregion

		#region public methods

		public GameObject buildGameObject(Entity entity ){

			GameObject entityObject = new GameObject ();

			entityObject.name = "Card " + entity.GameId;
			entityObject.layer = 1;

			SpriteRenderer spr = entityObject.AddComponent<SpriteRenderer> ();
			spr.sprite = Resources.Load<Sprite> ("sprites/" + "placeholder/dwarf");

			return entityObject;

		}

		#endregion
	}
}

