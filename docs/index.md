# Predictable Coding
These tips and tricks are designed to help you write cleaner, more maintainable code, and less prone to errors.

		
## What's in a name? Naming stuff is hard!

### Agenda
1. Why Naming Matters
2. The Should's, Do's & Don'ts of naming
3. Multi Tier Architecture Naming Considerations
4. Demo


### Why naming matters
Despite our best efforts, we spend far more time _reading_ others' code than we do writing our own (some have shown the ratio to be as high as 10:1). In light of
this fact, the skill of writing code that can be easily read and understood is invaluable.

Can you think of anything in software that doesn't have a name?  Likely not; names are at the root of almost all communication (to the point of being burdensome). 
What we want to think about today is how we can take the "burden" of naming and turn it into an advantage.

### The Should's, Do's & Don'ts of naming

#### Names Should...
- Indicate intent
- Provide context
- Distinguish between similar ideas
- Be easy to find

#### When naming, do...
- Follow relevant standards (industry, teamwide, domain "ubiquitous language", etc.)
- Rename variables from others' code if you have a better name in mind
- Use automation tools (IDE's, scripts, etc.) to make naming & renaming easier
- Have teamwide discussions about naming edge cases & standards

#### When naming, don't...
- Use abbreviated, shortened, or encoded names
	<script src="https://gist.github.com/prangel-code/9c6118bd9ce1a3771ff283d442ae56de.js"></script>
- Rely on comments & documentation to do a name's job
    <script src="https://gist.github.com/prangel-code/362405d336027053fa839e73044460b8.js"></script>
- Underestimate the value of good names

## Multi Tier Architecture Naming Considerations
- Bigger applications = More code
- Handle more code by splitting it
- Splitting code means more files
- Keeping track of what they are not as simple anymore

To illustrate: I will show you a small demo based off a client

Let me describe the scenario:
Our client uses the popular CMS platform called Sitecore. 
Sitecore has an architecture for managing code called helix.

The Helix architecture separates our code into 3 layers
- Project
- Feature
- Foundation


## Identifying your project's structure
Client wants web component
Requirements:
- User needs to enter an email address [UI, html]
- The email address and other pertinent data (like source) is recorded, packaged, and validated [controller, models]
- The data packet is sent to an Email Marketing Server via API for future usage [data context, api calls]

## Creating our project
[Start Demo]


### [Code is found under NamingIsHard_Code project]
### Foundation Layer [Hidden from audience]
The lowest module. Usually Libraries like JQuery or Database Context.
- Create Project
- Create ApiCall class(with Request Obj)
- Create Request Object
- Create Response Obj

### Feature Layer [Hidden from audience]
The equivalent to the business layer 
- Create Iterface IEmailSignup
- Implement Interface EmailSignup
- Instantiate Package Object
- Create Validation Object


### Project Layer [Hidden from audience]
This layer contains files that are specific to the project. Most of the times it is CSS, styles, and templates


# Making your code easy to test
## SubTopics
- Understand what specific functionality you are going to test
- Understand most common scenarios and situations
- Include Fail Scenarios (Nulls, etc)
- Just because it passes, it does not mean it works

### Understand what specific functionality you are going to test
Let's take the situation when you have code that does the following:
- Connects to an external server
- Sends a Get request with parameters, receives a response
- Returns the response in a usable instance of an object

The following is an example of what NOT to do:

<script src="https://gist.github.com/cjc061000/da5ed3daef1fd20aa7d3b492de9c5a6c.js"></script>

Hard to test if only one function
If the test fails, you don't know the real reason
The Key: limit functions to one thing at a time


Here is a better version of the code 

<script src="https://gist.github.com/cjc061000/28e46bd5eb6574a352fadb5c4dd71637.js"></script>

Different tasks are split up so that each can be tested independently
This allows us to truly know which step fails or passes 
The inclusion of the ``` SearchRequest ``` Object helps with readability/testability


### Include fail scenarios
Did your function really executed as intended?
Avoiding situations where we swallow, mask, or otherwise ignore errors and continue

<script src="https://gist.github.com/cjc061000/fcd9aa1cc675b92154743f3b0919e7c7.js"></script>

Code will not error out, and will continue "gracefuly"
It WILL bring trouble down the line, because "My code does not break"

Same code but better
<script src="https://gist.github.com/cjc061000/5135f7e44d14dab1e026e498e3e743a5.js"></script>

We can know if the connection was successful 
but we can also know what caused the error (if any)

### Just because it passes, it does not mean it works
We tend to seek information that re-inforces our current belief
We make an assumption, we look for ways to confirm that it is true
We tend to avoid situations (ie tests) that will make our assumption invalid

When writing test code, we need to need to include tests that will invalidate our assumption.

<script src="https://gist.github.com/cjc061000/7bbe07ef40668f8a8fabb3a53e72990f.js"></script>

Top function only checks if an item was returned
As long as search function returns something, test passes (bad)
The second function ensures the item retrieved is the intended one (better)

---------------------------

## Terse Code, Verbose Code, and Drawing the line
As we touched on in the naming discussion, we spend a lot of time reading code. Furthermore, we made the argument that in many cases using more descriptive
& informative names is a great way to guarantee clearer and, dare I say, _better_ code. So is more always more? Are there times when perhaps _less_ is more?
Enter, terseness:

<script src="https://gist.github.com/prangel-code/77e33ee3df369a3eaf28a749c3b81f85.js"></script>

### What is "terse" code?

__Terse:__ *Using minimal ~~words~~ syntax, devoid of superfluity.*

Many examples of terse code affirm the perception that it is "anti" readable code. And while readability should always be high on any developer's priority list,
there is an argument to be made that sometimes less readable code is preferred over verbose code.

Let's clarify what terse code is **NOT**:
- Writing single letter, abbreviated, or encoded variable names.
- Horribly abusing white space in a meaningless attempt to minimize lines of code.
- Indiscriminately chaining sequences of complicated syntax because "it compiles" and still meets requirements.

Instead, let's consider terse code to be code that takes advantages of higher level language features to abstract common logical patterns, resulting in less syntax
and less code. An example we have likely all seen is the ternary operator:

<script src="https://gist.github.com/prangel-code/9c4163ea3eaa5daf5e1552dcc06bda26.js"></script>

Without falling down the rabbit hole of pros and cons of minimal syntax like the ternary operator, let's agree on a few things:
- The ternary operator takes less space to acheive the same logical result
- Whether the ternary operator is more or less readable than a traditional if/else statement is _purely_ opinion and preference
- There are ways we can use ternary operators that we can not use if/else

So where is the balance? Let's look at another example.

[TerseTest.cs](https://github.com/ChuckkNorris/PredictableCoding/blob/b289c272e7a494beea5a53f30439260da710319e/src/UnitTestProject1/CounterTest.cs#L1)

### Drawing the line ... or at least trying
When trying to understand other perspectives, a great place to start is intent. What is the intent behind that perspective? For terse code it is clear that language 
features like ternary & null coalescing operators intend to package up common logical operations into compact and "intuitive" (up for debate) syntax. In other words,
if you're a fan of using modularization to reduce code duplication & alleviate code maintenance then there's an argument to be made that you should also be a fan
of terse code.

And yet, any non-terse coders are probably asking themselves "Yeah, but where do we draw the line?". Which sounds like a great opportunity for another bulleted list:
- Avoid accepting the excuse "I don't know what that syntax does."
- Communicate about team standards & best practices
- Readability is king, terse code should still be clean code

---------------------------

## Exception Handling

1. __Throw exceptions when inputs are invalid__
    
    You can quickly add null checks by pressing `CTRL`+`.` and selecting __Add null check__. This will enable you to quickly locate any argument specific errors
	
	[UserService.cs](https://github.com/ChuckkNorris/PredictableCoding/blob/master/src/Movie.Api/Entities/UserService.cs)

    <script src="https://gist.github.com/ChuckkNorris/3f38ffbf8954fc88f8971032dceabcc5.js"></script>

2. If implemented correctly, __you can leverage exceptions to quickly return user-friendly application error messages__
    
	For example, in a Web API, you can create a middleware which catches all exceptions and returns a friendly error messages to inform the user about exactly what went wrong while avoiding the need to implement a custom API response

    [ErrorHandlingMiddlware.cs](https://github.com/ChuckkNorris/PredictableCoding/blob/master/src/Movie.Api/Errors/ErrorHandlingMiddlware.cs)

	<script src="https://gist.github.com/ChuckkNorris/63cec141e0ed06540f1a11030c73d3f3.js"></script>

	Assuming that the email is expected to be validated by the client application, the request with user-friendly error and request specific error are returned
	![User Friendly Error](https://image.prntscr.com/image/sH3UmSr7RK_IkyQKHtxTQg.png)

	Here's a request with an invalid username or password but a correctly formatted email
	![Incorrect Password](https://image.prntscr.com/image/sQ4SKUvdTIqlXNA8RkY--A.png)
	
### Handling Null

1. __Plan for null__
    
    In general, if a value can be null, expect it to be. This will minimize potential null reference exceptions
    For instance, say you have a list of movies and actors which could potentially have null values, by using the *null conditional operator* and the *null coalescing operator* which will check to make sure the value isn't null before trying to access a child property or execute a chained function. Since this change alters the expression's result to be `Nullable<bool>` instead of `bool`, we can use the `??` to fallback to returning false if a value is null.
    Consider designing types that expose collection properties to leverage the "Null Object" design pattern (see Collections section)

	For example, say you're searching on a collection of Movies which could contain null values:

	[MovieService.cs](https://github.com/ChuckkNorris/PredictableCoding/blob/master/src/Movie.Api/Entities/MovieService.cs)

	<script src="https://gist.github.com/ChuckkNorris/251330525d59cda7468cb4fa95bcd9a2.js"></script>
    
	To ensure that you never throw null exceptions, expect that every value can be null and handle it appropriately

	[MovieService.cs](https://github.com/ChuckkNorris/PredictableCoding/blob/master/src/Movie.Api/Entities/MovieService.cs)

	<script src="https://gist.github.com/ChuckkNorris/fc22947a9a75e9c5c37af1ee722f3521.js"></script>
    
2. __Return null when it makes sense__ such as when an entity could not be found
	
	[UserService.cs](https://github.com/ChuckkNorris/PredictableCoding/blob/master/src/Movie.Api/Entities/UserService.cs)

    <script src="https://gist.github.com/ChuckkNorris/aaa8c4ea3451f2e8cb0a90df965b3bed.js"></script>
    
3. __Avoid passing null values as arguments__, but expect that arguments might be null and handle them appropriately
    
	For example, we make sure the email address isn't null or empty before instantiating the Regular Expression so that it doesn't throw a Null Reference exception and it also saves a few cycles performance-wise

	[Utilities.cs](https://github.com/ChuckkNorris/PredictableCoding/blob/master/src/Movie.Api/Utilities.cs)
    <script src="https://gist.github.com/ChuckkNorris/17a7b2a6f74a73e407cea23a584b6cbc.js"></script>
    

### Method Results

1. __Use informative method names__
    Method names should start with a *verb* followed by details explaining exactly what the method does
	- `GetUserByFirstName(string firstName);`
	- `GetUserByEmail(string email);`
	- `GetUserIfCredentialsAreValid(string username, string password);`

2. __SUGGESTION: Define the variable to return at the top of the method__
    
    This makes it easy for other developers to quickly track where the return value is being modified.  But beware of complexity within methods - if you must declare such variable at top, consider whether the method is doing too much and should be refactored.

	[Utilities.cs](https://github.com/ChuckkNorris/PredictableCoding/blob/master/src/Movie.Api/Utilities.cs)
    <script src="https://gist.github.com/ChuckkNorris/17a7b2a6f74a73e407cea23a584b6cbc.js"></script>

3. __Establish a convention for default return values__
    
    - If returning a collection, return an empty collection instead of null if no results are found (more about this below)
    - If returning a single object that's not found, returning null is often acceptable
    - Or, employ the Null-Object pattern as a common practice in your project

---------------------------

## Collections

1. __Avoid creating types which expose collection properties without properly initializing the collection__

	- Favor the use of the "Null Object" design pattern for collections
	- Always return an empty collection by default, to prevent `NullReferenceException` at runtime

2. __Encapsulate collection behaviors within your domain models__

	- Understand the side-effects of exposing your collection property with a public setter
	- Leverage .NET ReadOnly Collection types when possible
      - `.AsReadOnly()`
      
[DomainModels.cs example](https://github.com/ChuckkNorris/PredictableCoding/blob/d1c73241fc33ffa6cf4ab820f5d9ffe0f509ede0/src/PredictableCoding/Collections/DomainModels.cs#L5-L43)


3. __Choose the appropriate .NET collection type__

	- Understand the requirement, e.g. Performance, Fast Lookups, Sortability, Re-arranging and manipulation of elements, etc.
	- For most cases, you will either have to choose between a `List<T>` or `Dictionary<TKey, TValue>`
	- Avoid non-generic collection types (legacy .NET collections), such as `ArrayList` --> they require boxing/unboxing which adds overhead


4. __Expose collection properties as the "lowest common denominator" interface__

	- Unless you expect consumers of your type to directly mutate the items of the collection, you should use read-only forward-only `IEnumerable<T>` as the type of your collection property(s)
	- Avoid exposing collections as the derived implementation type, such as `List<T>` - those are meant to be internal implementation details
    
5. __Use LINQ Any vs. Count__

	- when checking if a collection contains elements, avoid counting, and use the `Any()` extension method instead
      - it is faster as it only needs to scan the collection till it finds the 1st element
      - do use predicates to filter your query without adding additional `Where()` calls

	[Count vs Any Code Sample](https://github.com/ChuckkNorris/PredictableCoding/blob/39240c66fa19d53519bcf48bc6a4e1dfd81bb5bc/src/PredictableCoding/Collections/LinqTips.cs#L12-L24)

6. __Know when to use LINQ "Query Syntax" vs. "Fluent" extensinon methods__

	- Query Syntax 
      - provides a syntactical sugar around the underlying extension methods
      - may be easier to write for **complex** queries, where lambdas become hard to read
    - Fluent Extension Methods
      - makes you more aware of method invocations, making it easier to identify lazy evaluations
      - encapsulate Where predicates into functions for better semantics and encapsulation

	[Fluent vs Query Syntax Code Sample](https://github.com/ChuckkNorris/PredictableCoding/blob/39240c66fa19d53519bcf48bc6a4e1dfd81bb5bc/src/PredictableCoding/Collections/LinqTips.cs#L26-L40)

---------------------------

## Dependency Injection Tips in .NET Core (concepts apply to other DI containers)

1. __Use Reflection to add services to the IOC container__

    For larger applications, manually adding services to the container can become tedious, and violates the "Open/Closed" principle. Instead, define a "marker" interface, and add all classes that implement it to the container

    [Startup.cs](https://github.com/ChuckkNorris/PredictableCoding/blob/master/src/Movie.Api/Startup.cs)

    <script src="https://gist.github.com/ChuckkNorris/b40f4ce134721c25024cb9364088ac63.js"></script>

2. As a rule of thumb, __limit constructor injected dependencies to 6 or less__

	If you find yourself needing more than 6, perhaps it's time for a refactoring - your service/type may have too much responsibility and violates the "Single-Responsibility" Principle (SRP)

3. To prevent circular dependencies, __don't inject services into other services__

	<script src="https://gist.github.com/ChuckkNorris/a465471971e51200930b5183a698167f.js"></script>

4. When to use different scopes
    1. Transient - New instance of class each time
	    
		If you're not sure what to use, use a transient to ensure that each class has its own clean instance of a particular dependency

    2. Scoped - New instance that lasts for the entirety of a request

	    Say that you've designed your application to batch save changes to the DbContext made by multiple services. With a scoped dependency, the same instance is used
		once per request, right before the request ends so that the same context service accesses the same context for the duration , you might scope your context to be Transient

		```csharp
		// Startup.cs
		// Configure DbContext as scoped dependency
		services.AddScoped<MyDbContext>();

		// MovieController.cs
		// Save the movie
		movieService.SaveMovie(newMovie);
		userService.UpdateUserMoviePreferences(userId, newMovie);
		// Commits both changes in single request to database
		await this._context.SaveChangesAsync();
		```

    3. Singleton - Single instance available for entire application aka multiple request threads will be using the same instance. 
	
	    Use this sparingly, but one reason to use singletons might be logging.
	    Say you have a single file that you log all exceptions to on the server. With a singleton scoped service, the exact same instance of your logger will be used for writing exceptions from all requests; This enables you to more easily build a thread-safe file writer and ensure that two different instances aren't trying to write to the same file.

---------------------------

## Enforcing C# Style Guides With StyleCop

StyleCop is a third-party tool that is widely adopted in the .NET community. StyleCop adds configurable styling rules to your project. When these rules are broken, the developer is warned or forced to make updates. 

The three main principles the StyleCop developers followed when creating StyleCop rules:
	
1. What are most teams doing already?
2. Which option is the most readable (highly subjective)?
3. Which option will be the easiest to maintain over time?

The rules cover concepts such as: documentation, maintainability, spacing, & readability. As mentioned in the rule creation principles, these topics can be highly subjective which is also why the rules are configurable. 

As seen in other areas of this document, it is clear why it is important for developers to establish a style guide and stick to it for the entirity of a project. Often times making these key decisions with maintainability & readability in mind can vastly improve the productivity of your team. Using StyleCop can ensure that a team stays consistent with their styling.

### Installing StyleCop
The easiest way to install the tool is by using Visual Studio's Extension and Updates dialog. Navigate to the Online section and search for StyleCop.

![Install StyleCop](https://image.prntscr.com/image/GSf-_ig_QaCkKnonF0ERSQ.png)

However, there is a nuget package option 

### Using StyleCop

Once you have installed StyleCop you will be able run it on the entire solution or any specific project. If the solution is large, it is advised to run for individual projects.

#### Accessing StyleCop Settings
StyleCop settings are maintained at a project level. To access the settings dialog, right-click on a project and choose "StyleCop Settings" from the menu.

![StyleCop Dialog](https://image.prntscr.com/image/_hQZqOXISmiIJNKGbQckMA.png)

__Q: Why would we want different rules for different projects?__

__A:__ 
Your team's emphasis on maintainability and readibility may be different based on the project. For example, maybe for your web application the team wants to be strict on variable naming, spacing, and readability so that code fixes can be implemented quickly without spending hours searching through a bundle of ternary operators or poorly named methods. Whereas, with a library-like project (i.e. repository), the rules could be strict on documentation (e.g. thorough, well documented summaries for all methods) and maintainability (e.g. debug asserts must provide message text.)

#### Manually Running StyleCop
StyleCop can be run at the project or solution level. If ran at the solution level, it will enforce the project-specific rules that have been configured. To run StyleCop, right-click the project or solution and choose "Run StyleCop".

Once Stylecop has finished running, you will see the violations in the error-list. Each violation description will start with a rule number, SAXXXX. If the rule description is not clear on how to fix the problem, this site can be useful:  
<a href="http://stylecop.soyuz5.com/StyleCop%20Rules.html">Style Cop Rules Guide</a>
