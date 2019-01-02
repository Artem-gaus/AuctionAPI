using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.IServices
{
    public interface IService<Entity> where Entity : class
    {
        Entity Get(int id);
        void Create(Entity entity);
        void Update(Entity entity);
        void Delete(Entity entity);
    }
}
