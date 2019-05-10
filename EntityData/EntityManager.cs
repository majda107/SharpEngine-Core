using SharpEngine_Core.RenderData;
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
    }
}
