# NumbersGame
This repo defines a .NET SDK that can be used for solving a numeric puzzle, based on the
integer-maths 4-operation puzzle popularised by C4's Countdown.

.NET developers are encouraged to implement the ISolutionProvider interface in order to submit
their algorithm to the local competition runner. TODO: This is on hold, but I'd like to take
the idea further - something maybe to engage with the outside world, or a bit of fun for
grads ...

Developers _may_ reuse other parts of the SDK as they wish, although no particular implementation
is mandated. In fact, the NumbersGamePlayer is intentionally _not_ optimal, nor are the two reference
algorithms that the SDK relies upon. TODO: I'd like to finish the 'speadfreaksolver' for a bit
of exercise with multithreading in C# (and draw a line in the sand for the competition...)

The SDK is then adapted and reused in an ASP .NET Web API 2 service, currently tied to the localhost - this will
be made configurable later on. 

We then have a Prism 5.0 MVVM WPF Desktop Client. The XAML is quite sophisticated (for a beginner!); our user
control is using a data template, is entirely driven by data and command property binding, uses both
static and dynamic resources, and makes of control template triggers.

The SDK and Console app are production-ready as are the reference implemetations; there's fairly thorough NUnit 
tests for all. The ViewModel is not just for abstraction and separation of concerns; it enables most
of the UI code to be unit-testable too, so there's unit tests in for that too.

I'm less thorough with the unfinished bits like the speedfreak solver.
