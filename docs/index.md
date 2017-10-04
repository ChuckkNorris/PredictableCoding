# Predictable Coding
These tips and tricks are designed to help you write cleaner code, less prone to errors

## Exception Handling
1. __Throw exceptions when inputs are invalid__
    
    You can quickly add null checks by pressing `CTRL`+`.` and selecting __Add null check__. This will enable you to quickly locate any argument specific errors
    <script src="https://gist.github.com/ChuckkNorris/3f38ffbf8954fc88f8971032dceabcc5.js"></script>
2. If implemented correctly, __you can leverage exceptions to quickly return user-friendly application error messages__
    
	For example, in a Web API, you can create a middleware which catches all exceptions and returns a friendly error messages to inform the user about exactly what went wrong while avoiding the need to implement a custom API response
	<script src="https://gist.github.com/ChuckkNorris/63cec141e0ed06540f1a11030c73d3f3.js"></script>

## Handling Null

1. __Plan for null__
    
    In general, if a value can be null, expect it to be. This will minimize potential null reference exceptions
    For instance, say you have a list of movies and actors which could potentially have null values, by using the *null conditional operator* and the *null coalescing operator* which will check to make sure the value isn't null before trying to access a child property or execute a chained function. Since this change alters the expression's result to be `Nullable<bool>` instead of `bool`, we can use the `??` to fallback to returning false if a value is null.
    Consider designing types that expose collection properties to leverage the "Null Object" design pattern (see Collections section)
	<script src="https://gist.github.com/ChuckkNorris/fc22947a9a75e9c5c37af1ee722f3521.js"></script>
    
2. __Return null when it makes sense__ such as when an entity could not be found
    <script src="https://gist.github.com/ChuckkNorris/aaa8c4ea3451f2e8cb0a90df965b3bed.js"></script>
    
3. __Avoid passing null values as arguments__
    
    If you want default logic, use optional arguments instead

## Method Results

1. __Use informative method names__
    Method names should start with a *verb* followed by details explaining exactly what the method does
	- `GetUserByFirstName(string firstName);`
	- `GetUserByEmail(string email);`
	- `GetUserIfCredentialsAreValid(string username, string password);`

2. __Define the variable to return at the top of the method__
    
    This makes it easy for other developers to quickly track where the return value is being modified

3. __Establish a convention for default return values__
    
    - If returning a collection, return an empty collection instead of null if no results are found
    - If returning a single object that's not found, returning null is often acceptable
    - Or, employ the Null-Object pattern as a common practice in your project


## Collections

1. __Avoid creating types which expose collection properties without properly initializing the collection__

	- Favor the use of the "Null Object" design pattern for collections
	- Always return an empty collection by default, to prevent `NullReferenceException` at runtime

[add pointer to code or demo here]

2. __Encapsulate collection behaviors within your domain models__

	- Understand the side-effects of exposing your collection property with a public setter
	- Leverage .NET ReadOnly Collection types when possible
      - `.AsReadOnly()`
      
[add pointer to code or demo here]

3. __Choose the appropriate .NET collection type__

	- Understand the requirement, e.g. Performance, Fast Lookups, Sortability, Re-arranging and manipulation of elements, etc.
	- For most cases, you will either have to choose between a `List<T>` or `Dictionary<TKey, TValue>`
	- Avoid non-generic collection types (legacy .NET collections), such as `ArrayList` --> they require boxing/unboxing which adds overhead

	[add pointer to code or demo here]

4. __Expose collection properties as the "lowest common denominator" interface

	- Unless you expect consumers of your type to directly mutate the items of the collection, you should use read-only forward-only `IEnumerable<T>` as the type of your collection property(s)
	- Avoid exposing collections as the derived implementation type, such as `List<T>` - those are meant to be internal implementation details

## Dependency Injection Tips

1. __Use Reflection to add services to the IOC container__
    For larger applications, manually adding services to the container can become tedious, and violates the "Open/Closed" principle. Instead, define a "marker" interface, and add all classes that implement it to the container
    <script src="https://gist.github.com/ChuckkNorris/b40f4ce134721c25024cb9364088ac63.js"></script>
2. As a rule of thumb, __limit constructor injected dependencies to 6 or less__
	If you find yourself needing more than 6, perhaps it's time for a refactoring - your service/type may have too much responsibility and violates the "Single-Responsibility" Principle (SRP)
3. To avoid circular dependencies, __try to avoid injecting services into other services__
	<script src="https://gist.github.com/ChuckkNorris/a465471971e51200930b5183a698167f.js"></script>
4. When to use different scopes
    1. Transient - New instance of class each time
    2. Scoped - New instance that lasts for the entirety of a request
    3. Singleton - Single instance available for entire application, aka multiple request threads will be using the same instance


# What's in a name? Naming stuff is hard!

** SubTopics **
- 1 Why Naming Matters
- 2 The Should's, Do's & Don'ts of naming
- 3 Multi Tier Architecture Naming Considerations
- 4 Demo


## Why naming matters
Despite our best intentions, we spend far more time _reading_ others' code than we do writing our own (some have shown the ratio to be as high as 10:1). In light of
this fact, writing code that can be easily read is an extremely valuable skill.

Can you think of anything in software that doesn't have a name?  Likely not; names are at the root of almost all communication (to the point of being burdensome). 
What we want to think about today is how we can take the "burden" of naming and turn it into an advantage.

## The Should's, Do's & Don'ts of naming

### The Should's
- Names should provide intent
- Names should provide appropriate context
- Names should distinguish between similar ideas
- Names should be easy to find

### The Do's
- Do follow relevant standards (industry, teamwide, domain "ubiquitous language", etc.)
- Do rename variables from others' code if you have a better name in mind
- Do use automation tools (IDE's, scripts, etc.) to make naming & renaming easier (e.g. use the "Rename" refactoring in Visual Studio instead of manual text changing)
- Do have teamwide discussions about naming edge cases & standards

### The Don'ts
- Don't underestimate the value of good names
- Don't use abbreviated or shortened names to save time (e.g. avoid Hungarian notation: `strFoo`, `iCounter`, `bFlag` )
- Don't use extraneous & redundant information in names
- Don't rely on comments & documentation to do a name's job

## Multi Tier Architecture Naming Considerations
When applications start growing, it starts becoming challenge to maintain, reuse, and scale code.
This is why there are frameworks like the multitier architecture that encourage separating code into modular manageable parts

So what is the big deal and how does naming conventions come into play?
Separating your code into modules inherently creates more objects (files)
New challenge comes in keeping track of and understanding what your modules do
This is where naming conventions can help us out

To illustrate: I will show you a small demo based on an implementation that we did for one of our clients

Let me describe the scenario:
Our client uses the popular CMS platform called Sitecore. 
Sitecore has an architecture for managing code called helix.

The Helix architecture separates our code into 3 layers
- Project
- Feature
- Foundation


## Identifying your project's structure
Our client wants us to implement web component in which a user can sign up for a marketing list and receive regular emails.
These are the requirements:
- User needs to enter an email address [UI, html]
- The email address and other pertinent data (like source) is recorded, packaged, and validated [controller, models]
- The data packet is sent to an Email Marketing Server via API for future usage [data context, api calls]

## Creating our project
The Helix architecture separates our code into 3 layers:
- Project
- Feature
- Foundation

[Show figure]
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

# Terse Code, Readable Code, and Drawing the line
As we touched on in the naming discussion, we spend a lot of time reading code. Furthermore, we made the argument that in many cases using more descriptive
& informative names is a great way to guarantee clearer and, dare I say, _better_ code. So is more always more? Are there times when perhaps _less_ is more?
Enter, terseness:

<script src="https://gist.github.com/prangel-code/77e33ee3df369a3eaf28a749c3b81f85.js"></script>

## What is "terse" code?

	*Terse:* _Using minimal ~~words~~ syntax, devoid of superfluity._

Many examples of terse code affirm the perception that it is anti-readable code. And while readability should always be high on any developer's priority list,
there is an argument to be made that "less readable" code is the way to go. To start, let's clarify what terse code is *NOT*:
- Writing single letter, abbreviated, or encoded variable names.
- Horribly abusing white space in a meaningless attempt to minimize lines of code.
- Chaining together endless sequences of complicated syntax because "it compiles" and does what it's supposed to.

Within

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

If you try to write a test that will try to do all of the 3 things in one test, you will have a bad time.
The reason being, if the test fails you don't know if it is because you don't have a connection, your response is not what you expected, or maybe the parameters are wrong.
The Key is to limit your test to really just test one thing at a time.

The following is an example of what NOT to do:
[BadDBSearch.cs](https://github.com/ChuckkNorris/PredictableCoding/blob/master/src/EasyToTestCode/BadDBSearch.cs)

<script src="https://github.com/ChuckkNorris/PredictableCoding/blob/master/src/EasyToTestCode/BadDBSearch.cs"></script>

All the functionality is stuck in one function. If an error occurs, there will be no way to know which part failed.

Here is a better version of the code. The different tasks are split up so that each can be tested independently. 
This allows us to truly know which step fails or passes. 
In addition, the inclusion of the ``` SearchRequest ``` Object helps with readability and escalability if at some point the parameters need to change.

[BetterDBSearch.cs](https://github.com/ChuckkNorris/PredictableCoding/blob/master/src/EasyToTestCode/BetterDBSearch.cs)

<script src="https://github.com/ChuckkNorris/PredictableCoding/blob/master/src/EasyToTestCode/BetterDBSearch.cs"></script>

### Include fail scenarios
An important point to always keep in mind is to have a way to know whether your function really executed as intended. It can be as simple as returning an error code.
We should get into the habit of avoiding those situations where we swallow, mask, or otherwise ignore errors and continue. Let's take a look at the following code.

```csharp
public void Connect(string connStr) 
{
	try
	{
		DBConnection.connect(connStr);
	}
	catch(Exception){}
}
```
Certainly if there is something wrong with the connection, our code will not error out, and will continue "gracefuly". 
It might, however, bring trouble down the line as we have no way to check whether a successful call happened. The following is a better example

```csharp
public class ConnStatus
{
	public bool isValid {get;set;}
	public string errMsg {get;set;}
}

public ConnStatus Connect(string connStr)
{
	var ctx = new ConnStatus();
	try
	{
		DBConnection.connect(connStr);
		ctx.isValid = true;
	}
	catch(Exception e)
	{
		ctx.isValid = false;
		ctx.errMsg = e.Message;
	}
}
```
With the expanded code above, we will not only be able to know whether the connection was successful, but we can also know what caused the error if one were to show up.

### Just because it passes, it does not mean it works
We tend to seek information that re-inforces our current belief.
If during our validation we make an assumption, we look for ways to confirm that it is true.
We tend to avoid tests that will make our assumption invalid


When writing test code, we need to need to include tests that will invalidate our assumption.
Let's take a look at ```BetterDBSearch``` class

[TestSearch.cs](https://github.com/ChuckkNorris/PredictableCoding/src/EasyToTestCode_UnitTest/TestSearch.cs)

The top function only checks if an item was returned from the search. 
That means that as long as the search function returns something we will pass.
This is not really testing our search capabilities properly, we are falling for our confirmation bias.
The second function on the other hand makes sure that the item retrieved is in fact the one that we intended, truly putting our search function to the test.

# Enforcing C# Style Guides With StyleCop

*INTRO* ---TODO

 StyleCop rules tend to encourage whitespace and openness in the code as well as lots of comments and documentation.

## Installing StyleCop
The easiest way to install the tool is by using Visual Studio's Extension and Updates dialog. Navigate to the Online section and search for StyleCop.

*_SCREENSHOT HERE!_*

## Using StyleCop
Once you have installed StyleCop you will be able run it on the entire solution or any specific project. If the solution is large, it is advised to run for individual projects. This is where the fun begins!

