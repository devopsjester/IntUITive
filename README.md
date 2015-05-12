# IntUITive
IntUITive is a UI testing library that enables testers to identify UI elements intuitively, which is to say, the same way that a user viewing the page would.

#How does it work?
IntUITive uses multiple algorithms to find a UI element, returning as soon as one algorithm succeeds. It will then remember (memoize) the control based on the bestidentifiable properties it can find.

For example, if IntUITive searches for "First Name", and it finds a textbox whose label reads "First Name", it will record the textbox's Id, name, and any other valuable properties, and use them the next time it runs, so that it can find the control faster.

#Search algorithms used by IntUITive:
1. Element Id
2. Cached properties
3. Element caption
4. Element placeholder
5. Label value with LabelFor attribute
6. Adjacent label
7. Hierarchically closest label
