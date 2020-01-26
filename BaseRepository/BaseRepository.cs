using System;
using System.Collections;

public interface IEntityRepository:IDisposable    
{        
    IEnumerable GetEntitys();        
    Entity GetEntityByID(int EntityId);        
    void InsertEntity(Entity Entity);        
    void DeleteEntity(int EntityId);        
    void UpdateEntity(Entity Entity);        
    void Save();    
}

public class EntityRepository:IEntityRepository    
{        
    private ApplicationContext context;        
 
    public EntityRepository(ApplicationContext context)        
    {            
        this.context = context;        
    }        
    
    public IEnumerable<Entity> GetEntitys()        
    {            
        return context.Entitys.ToList();        
    }        
    public Entity GetEntityByID(int EntityId)        
    {
        return context.Entitys.Find(EntityId);
    }
    
    public void InsertEntity(Entity Entity)
    {            
        context.Entitys.Add(Entity);      
    }        
    
    public void DeleteEntity(int EntityId)        
    {            
        Entity Entity = context.Entitys.Find(EntityId);                    
        context.Entitys.Remove(Entity);        
    }        
    
    public void UpdateEntity(Entity Entity)        
    {            
        context.Entry(Entity).State = EntityState.Modified;        
    }        
    
    public void Save()        
    {            
        context.SaveChanges();        
    }        
    
    private bool disposed = false;        
    
    protected virtual void Dispose(bool disposing)        
    {            
        if (!this.disposed)            
        {                
            if (disposing)                
            {                    
                context.Dispose();                
            }
        }            
        this.disposed = true;        
    }        
    
    public void Dispose()        
    {            
        Dispose(true);            
        GC.SuppressFinalize(this);        
    }    
}

