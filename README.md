# nameParserUnitTesting

### Project Description 

This exercise is an introduction to using Unit Testing for driving program development. 

Program functionality is given via User Stories.


### Specs
User Stories are given in the form:
```
Story:
    As a User registering for the Stuff app
    I want to be able to enter all of my name information into one box
    So that I don't have to waste time hitting the tab button

        Scenario:
            Given a User registering with the name 'Zendaya'
            When parsing the name
            Then the first name field should be 'Zendaya'
```

- Wrote Unit Tests for 12 cases, all of which passed
- Tests are set-up as both `Fact` and `Theory`
- Defined the Class `Parser` in `Parser.cs`, which parses all of the cases that are passed in as the string `name`
- After the 12 cases all successfully Passed, refactored the code in `Parser.cs`

#### The 12 Name Cases
- `"Zandaya"`
- `"Steve Jones"`
- `"Mary Barnes-Jones"`
- `"Steve L. Jones"`
- `"Steve X Jones"`
- `"Bob Marley Jr."`
- `"Bob Marley Esq"`
- `"Mr. Bob Michaels"`
- `"Mr. Bob Michaels"`
- `"P J O'Rourke"`
- `"C. S. Lewis"`
- `"Mr. C. S. Lewis PhD"`


### Technologies Used
- `C#`
- Visual Studio Code


```
git clone https://github.com/SMITHsharon/nameParserUnitTesting.git
cd nameParserUnitTesting
```

### Contributor
[Sharon Smith](https://github.com/SMITHsharon)
