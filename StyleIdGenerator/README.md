# Why Native Cells?
* Type Safety
* Speed
* Compiler time errors

#How it works?
The startFolder path is scanned for all xaml files containing usages of StyleId="%value%". A struct is then created for each file, allowing you to reference the ids via a strongly typed class (StyleIds).

# Setup
Setup for now is manual (nuget coming soon). Copy the StyleIdGenerator.t4 and StyleIdGenerator_Config.tt to your solution. 

# Usage
Update the startFolder variable in the StyleIdGenerator_Config.tt to point to the root of your solution. 
For a detailed example clone the repo and take a look at the UITests project.

# License
Licensed under main repo license
