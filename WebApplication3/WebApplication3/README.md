# Scoped
In this service, with every HTTP request, we get a new instance. The same instance is provided for the entire scope of that request.

# Transient
A new service instance is created for each object in the HTTP request. This is a good approach for the multithreading approach because both 
objects are independent of one another.

# Singleton
The Singleton scope creates a single instance of the service when the request for it comes for the first time. After that for every subsequent 
request, it will use the same instance. The new request does not create the new instance of the service but reuses the existing instance.



# When to use which Service
Singleton approach => Singletons should rarely be used. One use-case is if you have a global store of some kind, e.g. a cache, logging service, email service
which should be shared between requests.

Scoped approach => Scoped can be used for Entity Framework database contexts. The main reason is that then entities gotten from the database will
be attached to the same context that all components in the request. Usually we use scoped services to ensure some processing is done only 
once per request

Transient approach => Transient would be used when the component cannot be shared. A non-thread-safe database access object would be one example. 
Transient services should be the default. Constantly re-creating services reduces the risk of a faulty implementation bringing everything down, 
since every new instance will be created in a non-faulty state.