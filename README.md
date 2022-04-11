# Introduction 
TODO: Give a short introduction of your project. Let this section explain the objectives or the motivation behind this project. 

# Getting Started
TODO: Guide users through getting your code up and running on their own system. In this section you can talk about:
1.	Installation process
2.	Software dependencies
3.	Latest releases
4.	API references

# Build and Test
TODO: Describe and show how to build your code and run the tests. 

### Test suites
- **@Smoke** - tests to cover critical ETL functionality like file parsing, difference calculation and saving difference in master database.
Scenarios inside one feature file depend on each other and should be executed in a specific sequence defined in feature file.  
Feature test flow:
    - Scenario 01 - Initial load of price file on clean database. Verify raw data and calculated differences in database.
    - Scenario 02 - Load updated price file for the same market. Verify raw data and calculated differences in database.
    - Scenario 03 - Load same file without changes. Check that file is not processed.    
<br />
- **@Validation** - tests to cover File/Record/Field validation cases with error/warning message verification in ETL process. 
Scenarios in this suite are independent and can be run separately.


# Contribute
TODO: Explain how other users and developers can contribute to make your code better. 

If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)