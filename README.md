### repository-pattern
==================

#### Why? 

#### Extending IEntity
```csharp
public partial class Foo : Entity
{
    public string Name
    {
        get;
        set;
    }
}
```

#### Extending IRepository
```csharp
public static class FooRepository
{
    public static DL.Foo GetByFooName(this IRepository<DL.Foo> repository, string foo)
    {
        if (string.IsNullOrEmpty(foo))
            return null;
        return repository.FirstOrDefault(x => x.Name == foo);
    }
}
```

#### Usage

##### New instance of UnitOfWork
```csharp
UnitOfWork uow = new UnitOfWork();
```

##### Create
```csharp
uow.Repository<DL.Foo>().Add(new Foo() { Name = "foo" });
```

##### Find one
```csharp
var foo = uow.Repository<DL.Foo>().FirstOrDefault(x => x.Name = "foo" );
```

##### Update
```csharp
foo.Name = "bar";
uow.Repository<DL.Foo>().Update(foo);
```

##### Remove
```csharp
uow.Repository<DL.Foo>().Remove(foo);
```

##### Find several records
```csharp
var results = uow.Repository<DL.Foo>().Where(x => x.CreatedDate < DateTime.Now);
```

##### Save Changes
```csharp
uow.Commit();
```
