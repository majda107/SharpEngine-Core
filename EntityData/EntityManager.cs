using SharpEngine_Core.RenderData;
using SharpEngine_Core.Solids;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpEngine_Core.EntityData
{
    class EntityManager
    {
        public List<IEntity> Entities { get; private set; }
        public EntityManager()
        {
            this.Entities = new List<IEntity>();
        }

        public void Add(IEntity entity)
        {
            this.Entities.Add(entity);
        }

        public void RenderVisible()
        {
            foreach(IEntity entity in this.Entities)
            {
                if(entity is IRenderable)
                {
                    (entity as IRenderable).Render();
                }
            }
        }


        /// <summary>
        /// DEBUG; MAY CHANGE LATER!
        /// </summary>
        public void UpdateSolids()
        {
            foreach (IEntity entity in this.Entities)
            {
                if (entity is ASolid)
                {
                    (entity as ASolid).PhysicBody.UpdateForces();
                }
            }
        }

        public ASolid CheckCollisionsFor(ASolid solid)
        {
            foreach(IEntity entity in this.Entities)
            {
                if(entity != solid && entity is ASolid)
                {
                    if(solid.CheckCollide(entity as ASolid))
                    {
                        return (entity as ASolid);
                    }
                }
            }

            return null;
        }
    }
}
