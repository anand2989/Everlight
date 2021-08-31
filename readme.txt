Fernway Partners  Assignment :- Everlight QA automation

How to open the Project :
--------------------------

You need to clone the project from the git url (https://github.com/anand2989/Everlight.git) and download to your local machine. After the cloning part is done, 
need to open the folder and search for the Everlight Automation.sln and have to open file with the Visual studio in you local machine. 

---------------------------
How to execute the project :
---------------------------

Once the project is opened in the Visual studio, you need to clean and build the code, so that you'll se if there are any erros in the code.

Once the code is build, click on the test explorer and you will be seeing the available test runs in the test explorer.

Select all the tests and click on the run.

------------
Tools Used :
-------------

I have selected the C# and Visual Studio as mentioned in the email. I can automate this project in Java also.

a. Selenium webdriver (version- 3.14)
b. Language- C#
C. Page object model
e. Nunit
f. Visual studio


----------------------------------------------
Test Cases for the ComputerBased Application : 
----------------------------------------------

As in the time consideration, I have come up with  test cases for the computer based application. Below are the five test cases and flow respectively.

Test Case 1 : Add New Computer to database
---------------------------------------------

a. Navigate to the url and click on the add new computer.
b. You will be navigated to the details page, enter all the manditory details
c. Click on the Create computer 
d. On creation you will be able to see the created computer in the successfull message popup -- expected output

Test Case 2 : Cancel - Add New Computer to database
---------------------------------------------------

a. Navigate to the url and click on the add new computer.
b. You will be navigated to the details page, enter all the manditory details
c. Click on the cancel button 
d. On clicking on the cancel button you will not be able to see the created computer in the message popup -- expected output


Test Case 3 : Edit existing computer
---------------------------------------------------

a. Navigate to the url 
b. Enter for the required computer name.
c. click on the search button
d. Required computer name will be displayed
e. Select the computer name 
f. Edit the reuired details 
g. Click on the save compueter details button
h. On saving the data you will be able to see the saved computer data in the successfull message popup -- expected output


Test Case 4 : Search for existing computer
---------------------------------------------------
a. Navigate to the url 
b. Enter for the required computer name.
c. click on the search button
d. Required computer name will be displayed

Test Case 5 : Verify Total Number of computers
---------------------------------------------------
a. Navigate to the url 
b. Click on the dashboard and you will be able to see the total available computers in the db. -- expected output


----------------------
Framework Components :
----------------------

1. Configuration Foldder : 
----------------------

a. This folder is to store the config, env properties which are used in the automation execution
b. In this folder as per this project it has the config file which contails the url, browser name and etc.

---------------------
2. Extensions Folder
---------------------

a.  This folder is the extentions for the webdriver wait that we will be using the in automation.

-------------------------
3. Extent Report Folder :
-------------------------

This folder has the class file which has methods to generate the extent report for the test execution. Also It has the extent report generated for this test execution


----------------------
4. Page Object Model :
----------------------

This folder contians two POM files as follows,

ComputerBasedHomePage : 
---------------------

a. This file contains the objects in the compueter baded home page.
b. Contains the business login functions perfomed agains the objects

JavaScriptAlertHomePage :
-----------

a. This file contains the objects in the Java script alert home page.
b. Contains the business login functions perfomed agains the objects

BasePage :
----------

a. This class file contains the common functions which will be used in the script.

WebElementLocators:
-------------------

This class file contains the webelement locators like xpath, css

Resources : 
-----------

This folder contains the below resources used in the execution

TestData:
---------

a. This is resource file (resx) which is used to store the test data required for executing the scripts

------------------
5. Properties File
------------------

This class file is used to retrieve the data from the config file mainly config properties which are used in the execution

7. Tests
---------

This folder will store the UI tests for the both computer based and javascript alers applications

ComputerDatabaseTests :
-----------------------

This class file stores the test cases which are developed for the computer based application

JavaScriptAlertTest :
-------------------

This class file stores the test cases which are developed for the Javascript alerts application

BaseTest:
---------

This class file stored all the browser related actions like invoking the required browser.

Note : 
------

a. I have used Resource file to store the test data and to retireve the data from it. In our current project we are using MySql db to store the test data and test results which we will populate in separate UI.

e. I have written the code comments in the project.

Time taken to complete the this challenge :
-----------------------------------------

a. It took me around 1 hour to complete the framework with xunit and the extent report

b. It took me around one and half hour to complete the scripting part for both the applications

c. One hour for running and debugging the code

b. It took me for an hour to write the read me file.

c. It took me about an half hour to see the consistency of the framework and script.

Overall it took me around 4 to 5 hours to complete this task succesfully.

