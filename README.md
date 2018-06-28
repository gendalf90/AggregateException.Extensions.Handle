# AggregateException.Extensions.Handler

Extension of AggregateException for strongly typed handling. It is wrapper over `Handle` method.

### Getting started

Install from [NuGet](https://www.nuget.org/packages/AggregateException.Extensions.Handler/):

```powershell
Install-Package AggregateException.Extensions.Handler
```

Use namespace:

```csharp
using AggregateExceptionExtensions.Handler;
```

### Exception handling

If you want to handle exception which aggregated in AggregateException you can write like this:

```csharp
try
{
  SomeMethodAsync();
}
catch(AggregateException ae)
{
  ae.Flatten()
    .AddHandlers()
    //Handling occur in the order which handlers are defined
    .Handler<ArgumentNullException>(e =>
    {
      Console.WriteLine(e.Message);
    })
    .Handler<ArgumentException>(e =>
    {
      Console.WriteLine(e.Message);
    })
    .Handle();
}
```

Also, you can specify some condition for handling of the current type:

```csharp
try
{
  SomeMethodAsync();
}
catch(AggregateException ae)
{
  ae.Flatten()
    .AddHandlers()
    .Handler<ArgumentException>(e =>
    {
      if(e.ParamName != "asdf")
      {
        return false;
      }
      
      Console.WriteLine(e.Message);
      return true;
    })
    .Handle();
}
```
