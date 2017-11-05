# Nu- Prescriber: Simple Prescription application for Doctors

__℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞
_℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞
℞℞____℞℞_______________________℞℞
℞℞_℞℞__℞℞_______________________℞℞
℞__℞_℞__℞℞_______________________℞℞
_℞℞℞℞℞℞_℞℞________________________℞℞
__℞℞℞℞__℞℞_________________________℞℞
_________℞℞_________________________℞℞
________:℞℞_________________________℞℞
________℞℞_________________________:℞
________℞℞____℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞
________℞℞__℞℞℞_℞℞℞____________________℞
_________℞℞__℞℞℞℞℞℞____________________℞
__________℞℞___℞℞℞___________________℞℞℞
___________℞__℞℞℞___________________℞℞℞
____________℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞℞


## Motivation:
We heard rumors that doctors may have to list active ingredients in the proprietary drugs that they prescribe. Nu-Prescribe is a simple solution for supporting this workflow. 

## How to use:
Clone this repo, install docker and just docker-compose up.(Or click the run button in Visual studio after opening this project)
Just explore the application, and you will know what it does.

## How to develop:
This is a simple ASP.NET core 1.1 application using SQLite backend. This could be a nice learning project. Help is needed to add the search functions and improving the interface. The tutorial at https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/ is all that you need to get going!
Read contributing.md for details.

## Disclaimer:
This is not production ready and probably never will be. But you are the adventurous type. Aren't you?

## Data Model

### Proprietary:Ingredients is M:N. It is corrected in the code, but not on this diagram.

![Nu Prescriber](https://raw.github.com/dermatologist/nu-prescriber/master/NuPrescriber/Docs/ER-Model.JPG)