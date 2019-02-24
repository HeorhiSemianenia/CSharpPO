# C_Sharp_Framework

This framework consists of following technologies:

1. C#
2. Selenium WebDriver
3. NUnit
4. Log4Net
5. RestSharp
5. Allure


# Allure configuration

1.In order to generate a report, we should install Allure comand-line interpreter.

а) Download the latest version as a zip archive from bintray.

b) Unpack the archive to allure-commandline directory.

c) Navigate to **bin** directory.

d) Add **allure** to system PATH.

2.Run tests with any test runner. Generated Allure reports will appear in directory you configured with allureConfig.json

3.Open the report through the following CMD command:

`allure open "allure-report-directory"`

OR

Open a command prompt screen, go to the project directory, and write below command:

`allure serve allure-results`

If you want to generate report in permanent folder follow command:
`allure generate <directory-with-results>`