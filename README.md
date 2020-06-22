# Leatherback

## Why did I make this
I don't like the scaffolding functionality, I wanted to have something more simliar to how Django can generate an API based on models.
So I made this, as no one on stackoverflow seemed to give me any answers on a similar project.

## Why the name Leatherback?

Initially I named this project turtle, but now its just called Leatherback, which is some fast swimming turtle.

## What you need:
- EF Core 3.1+ 
- Use MS SQL with EF Core (Gonna look at this later on how to support other DBs)



## How to use this:

1) Define a few models, and either use Data Annotation, or all the other options available in EF.
2) If you want a special Model for search operations, define one aswel.
3) Create a DBContext and define all the DbSets you want tables for.
4) Register this Framework with:
       ```services.UseTurtle<YourDbContextHere>(YourConnectionStringHere);```
5) Run EF Migrations.
6) Run your solution, you should have a working API.



