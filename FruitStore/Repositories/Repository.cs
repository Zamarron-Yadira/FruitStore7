using FruitStore.Models.Entities;

namespace FruitStore.Repositories
{
	public class Repository<T> where T:class
	{
        //(sirve para cualquier tabla)todos los repositorios hacen esto:
        public Repository(FruteriashopContext context)
        {
			Context = context;
		}

		public FruteriashopContext Context { get; }

		//habilitar el polimorfismo con virtual:
		public virtual IEnumerable<T> GetAll()
		{
			//regresa todo el conjunto de entidades
			return Context.Set<T>();
		}
		public virtual T? Get(object id)
		{
			return Context.Find<T>(id);
		}

		public virtual void Incert(T entity)
		{
			Context.Add(entity);
			Context.SaveChanges();
		}
		public virtual void Update(T entity)
		{
			Context.Update(entity);
			Context.SaveChanges();
		}
		public virtual void Delete(T entity)
		{
			Context.Remove(entity);
			Context.SaveChanges();
		}

		public virtual void Delete(object id) /*por si se elimina solo con id*/
		{
			var entity = Get(id);
			if (entity!=null)
			{
				Delete(entity);
			}
			
		}
	}
}
