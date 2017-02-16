# SuperGrouperService

Super Grouper is a RESTful web service which allows a client to create groups and partitions of groups.

## Terms:
Group: a collection of members, e.g. students in Mr. Smith's class  
Groupable Template: a criterion which is used to create groupables, e.g. test score  
Groupable: a representation of a member and its groupable criteria, e.g. Suzy's test score  
Partition: a collection of subgroups of a group for which every groupable is in exactly one group

## Getting Started
Currently Super Grouper can only be run locally. Its default launch page uses Swagger UI, allowing users to easily interact with the APIs. In order to use the Super Grouper service you'll need to install Visual Studio and MongoDB. Make sure to restore all NuGet packages before attempting to build the solution.

## Super Grouper APIs Example Usage
1) Create a group named Chores with members "Make bed", "Clean out fridge", "Clean toilet", and "Wash dishes".
2) Create a groupable template with name "Difficulty"
3) Create groupables for "Make bed" - Difficulty: 1, "Clean out fridge" - Difficulty: 5, "Clean toilet" - Difficulty: 2, and "Wash dishes" - Difficulty: 3.
4) Request a partition of "Difficulty" with two balanced groups. (Example response: [Make bed, Clean out fridge], [Clean toilet, Wash dishes])
