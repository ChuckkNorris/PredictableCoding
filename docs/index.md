# Basics

# Properties
If you need to clean data, take advantage of properties

[Movie.cs](https://github.com/ChuckkNorris/PredictableCoding/blob/master/Entities/Movie/Movie.cs)

<script src="https://gist.github.com/ChuckkNorris/ea72da075116adf3539daa424d4e0052.js"></script>



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
- 1 
- 2
- 3


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
[BadDBSearch.cs](https://github.com/ChuckkNorris/PredictableCoding/blob/master/PredictableCoding/Testing/BadDBSearch.cs)

<script src="https://gist.github.com/ChuckkNorris/ea72da075116adf3539daa424d4e0052.js"></script>

All the functionality is stuck in one function. If an error occurs, there will be no way to know which part failed.

Here is a better version of the code. The different tasks are split up so that each can be tested independently. 
This allows us to truly know which step fails or passes. 
In addition, the inclusion of the ```markdown SearchRequest ``` Object helps with readability and escalability if at some point the parameters need to change.

[BetterDBSearch.cs](https://github.com/ChuckkNorris/PredictableCoding/blob/master/PredictableCoding/Testing/BetterDBSearch.cs)

<script src="https://gist.github.com/ChuckkNorris/ea72da075116adf3539daa424d4e0052.js"></script>
