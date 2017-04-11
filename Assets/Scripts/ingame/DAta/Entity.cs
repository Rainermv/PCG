using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.PDev.PCG.Data
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

        public int debug_value = 0;

		#endregion

		#region private variables

		int game_id = 0;
		int owner = 0;
		int max_children = 10;

		Entity parent = null;

        Dictionary<int, Entity> children = new Dictionary<int, Entity>();
        Dictionary<int, Attribute> attributes = new Dictionary<int, Attribute>();
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

				this.children.Add (entity.game_id, entity);
				entity.parent = this;

			} else {
				Debug.LogError("Entity " +  GameId + ": can't add child, max number of children reached");
			}
		}

        public Entity findChild(int id)
        {
            Entity child = null;
            if (children.TryGetValue(id, out child))
            {
                return child;
            }

            foreach (int key in children.Keys)
            {
                child = children[key].findChild(id);
                if (child != null )
                {
                    return child;
                }
            }

            return null;
        }

		#endregion
	}
}

