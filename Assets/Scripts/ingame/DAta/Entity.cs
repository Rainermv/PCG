using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.PDev.PCG
{
	public class Entity
	{

		#region public proprieties

		public int GameId {
			get {
				return game_id;
			}
			set {
				game_id = value;
			}
		}

		#endregion

		#region private variables

		int game_id = 0;
		int owner = 0;
		int max_children = 10;

		Entity parent = null;

		List<Entity> children = new List<Entity>();
		List<int> visibility = new List<int>(); // TODO turn into enum

		#endregion

		#region private methods



		#endregion

		#region public methods

		public Entity ()
		{
		}

		public void addChild(Entity entity){

			if (children.Count < max_children) {

				this.children.Add (entity);
				entity.parent = this;

			} else {
				Debug.LogError("Entity " +  GameId + ": can't add child, max number of children reached");
			}
		}

		#endregion
	}
}

