# Exception Handling
1. When to throw e

# Handling Null

1. __Plan for null__

In general, if a value can be null, expect it to in order to minimize potential null reference exceptions
<script src="https://gist.github.com/ChuckkNorris/fc22947a9a75e9c5c37af1ee722f3521.js"></script>

2. __Return null when it makes sense__ such as when an entity could not be found
<script src="https://gist.github.com/ChuckkNorris/aaa8c4ea3451f2e8cb0a90df965b3bed.js"></script>

3. __Avoid passing null values as arguments__

If you want default logic, use optional arguments instead

# Method Results

1. __Use informative method names__

2. __Define the variable to return at the top of the method__

This makes it easy for other developers to quickly track where the return value is being modified

3. __Establish a convention for default return values__

    1. If returning a collection, return an empty collection instead of null if no results are found
    2. If returning a single object that's not found, returning null is often acceptable

# Dependency Injection Tips

1. __Use Reflection to add services to the IOC container__
	For larger applications, manually adding services to the container can become tedious. Instead, extend an interface and add all classes that implement it to the container
2. As a rule of thumb, __limit constructor injected dependencies to 6 or less__
	If you find yourself needing more than 6, perhaps it's time for a refactor
3. To avoid circular dependencies, __try to avoid injecting services into other services__
<script src="https://gist.github.com/ChuckkNorris/a465471971e51200930b5183a698167f.js"></script>
4. When to use different scopes
    1. Transient - New instance of class each time
    2. Scoped - New instance that lasts for the entirety of a request
    3. Singleton - Single instance available for entire application, aka multiple request threads will be using the same instance

### Markdown

Markdown is a lightweight and easy-to-use syntax for styling your writing. It includes conventions for

```markdown
Syntax highlighted code block

# Header 1
## Header 2
### Header 3

- Bulleted
- List

1. Numbered
2. List

**Bold** and _Italic_ and `Code` text

[Link](url) and ![Image](src)
```

# What's in a name? Naming stuff is hard!
## SubTopics
- 1 Multitier Architecture
- 2 Identifying your project's structure
- 3 Creating

## Architecture patterns and practices
When developing an application, if it is small enough it can be easy just to simply add all your functions and classes in one file.
But when applications start growing, it can start becoming a challenge to maintain, reuse, and scale code.
This is why there are frameworks like the multitier architecture that encourage separating code into modular manageable parts

So what is the big deal and how does naming conventions come into play?
Because separating your code into modules inherently creates more objects (files) to keep track of, 
the new challenge comes in keeping track of and understanding what your modules do.
This is where naming conventions can help us out.

To illustrate the benefits of adhering to solid naming conventions, I will show you a small demo based on an implementation that we did for one of our clients.

Just a bit about our client and the scenario:
Our client uses the popular CMS platform called Sitecore. 
Sitecore has an architecture for managing code called helix. 
[Show picture]

I will show you the naming conventions we used for the project and how it organically organizes our code.

## Identifying your project's structure
Our client wants us to implement web component in which a user can sign up for a marketing list and receive regular emails.
These are the requirements:
- User needs to enter an email address
- The email address and other pertinent data (like source) is recorded, packaged, and validated
- The data packet is sent to an Email Marketing Server via API for future usage

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

<script src="https://gist.github.com/ChuckkNorris/ea72da075116adf3539daa424d4e0052.js"></script>

All the functionality is stuck in one function. If an error occurs, there will be no way to know which part failed.

Here is a better version of the code. The different tasks are split up so that each can be tested independently. 
This allows us to truly know which step fails or passes. 
In addition, the inclusion of the ``` SearchRequest ``` Object helps with readability and escalability if at some point the parameters need to change.

[BetterDBSearch.cs](https://github.com/ChuckkNorris/PredictableCoding/blob/master/src/EasyToTestCode/BetterDBSearch.cs)

<script src="https://gist.github.com/ChuckkNorris/ea72da075116adf3539daa424d4e0052.js"></script>

### Include fail scenarios
An important point to always keep in mind is to have a way to know whether your function really executed as intended. It can be as simple as returning an error code.
We should get into the habit of avoiding those situations where we swallow, mask, or otherwise ignore errors and continue. Let's take a look at the following code.

```
public void Connect(string connStr) {
	try{
		DBConnection.connect(connStr);
	}
	catch(Exception){}
}
```
Certainly if there is something wrong with the connection, our code will not error out, and will continue "gracefuly". 
It might, however, bring trouble down the line as we have no way to check whether a successful call happened. The following is a better example

```
public class ConnStatus{
	public bool isValid {get;set;}
	public string errMsg {get;set;}
}
public ConnStatus Connect(string connStr) {
	var ctx = new ConnStatus();
	try{
		DBConnection.connect(connStr);
		ctx.isValid = true;
	}
	catch(Exception e){
		ctx.isValid=false;
		ctx.errMsg = e.Message;
	}
}
```
With the expanded code above, we will not only be able to know whether the connection was successful, but we can also know what caused the error if one were to show up.

### Just because it passes, it does not mean it works
Let's play a game. Let's say you have code that displays the following prompt:

Here is a sequence of numbers. What is the next correct number?
- 2
- 4
- 8 
- ??

Which of the following numbers will pass the test?
- 1
- 16
- 9
- 10

*Count hands*
The correct answer is 16, 9 and 10, because the algorithm only tests whether the input number is greater than the previous (8).
So logically you pick 16, and maybe 1 to "test" your hypothesis. 
But few will pick the remaining because we tend to seek information that re-inforces our current belief.
Thought process:
1. I assume the pattern is: previous number x 2
2. I pick 16, and program returns true
3. Because I guessed correctly, I assume that my understanding of the program is correct
4. Because I believe to be correct, I don't try again with numbers I "know" will fail (9, 10)
This is confirmation bias.

When writing test code, we need to be aware of confirmation bias and guard against it. Let's write a test for our ```BetterDBSearch``` class
[TestSearch.cs](https://github.com/ChuckkNorris/PredictableCoding/blob/master/src/EasyToTestCode/TestSearch.cs)

<script src="https://gist.github.com/ChuckkNorris/ea72da075116adf3539daa424d4e0052.js"></script>

The top function only checks if an item was returned from the search. That means that as long as the search function returns something we will pass.
This is not really testing our search capabilities properly, we are falling for our confirmation bias.
The second function on the other hand makes sure that the item retrieved is in fact the one that we intended, truly putting our search function to the test.

How to guard against confirmation bias? It is tricky, and not a straight answer. Just by realizing that we all have inherent bias in us we can try to avoid it before it comes back to haunt us.
