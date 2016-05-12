# Test

Write a console application that processes a word list. The application should print all the 6-letter words from the list, that can be obtained by concatenating two other words from the list.

An example: The word “albums” is printed, because the words “al”, “bums” and “albums” are in the word list.

Print the result as follows:

```
al + bums => albums
bar + ely => barely
be + foul => befoul
con + vex => convex
here + by => hereby
jig + saw => jigsaw
tail + or => tailor
we + aver => weaver
```

### Remarks
- The word list is in the wordlist.txt file, located on your desktop.
- Pay special attention to the readability of your code, as well as the extendibility/flexibility.
- Make sure that the performance of your solution is acceptable.
- Use OO principles.
- Optional: Initialise a local git repository and indicate your progress by using small commits.
- Optional: TDD.

### Timing
- Expected duration: 45 min.
- We’ll check every 15 minutes, to see how things are going.
- Not finished? No problem. The main focus of this assignment is to get an idea of your method of problem solving, and of your code style. Make sure that what you are coding, is something you are proud of.

### Additional questions
- How did you begin to solve this problem? What were your first steps?
- Do your classes follow the Single Responsibility Principle?
- How would you have to change your code, to make it work with millions of words, instead of thousands?
- What would you have to change when the length of the word changes?
- If you had unlimited time, how would you improve your solution?
- Can you draw a model of the ideal solution, in your opinion?
- Could you identify reusable parts, and find good names for them?
- Use Dependency Injection / Inversion of Control?
- How would you go about making this project ultra-performant? 

### Notes about the code
- This is an example solution. As with everything in the software development world, many of the choices are debatable.
- This solution was created during several hours of refactoring and debating amongst colleagues. It seems to be humanly impossible to deliver this result in just 45 minutes (but never say never...). But it gives you a rough idea of our coding style. Giving only 45 minutes, gives us a descent idea of how you make difficult choices under time pressure.
- We use AutoFac as a IoC container. This might seem as overkill for this kind of small solution (and it probably is). Again, it is intended to be representative for our code. But Poor Man's DI would have worked just fine.

### Change log
v1.0.1 - 2016-05-12
- Add license.
- Implemented some minor refactoring suggestions.

v1.0.0 - 2016-05-02
- Initial release.