Thanks for thinking about contributing to the project! All suggestions, bugs, even typo fixes are most appreciated

Please open an issue and have a chat about any features you're thinking of implementing before you start,
so we can discuss the best way to go about it

## Purpose

Our aim when making this library was to keep it small, lightweight, and easy to use. We'd rather not 
have more complex features that'd bloat its size or complexity.

## Running

Clone out the repo, fire up with Visual Studio 2017, and run all the tests.
When working on the feature don't forget to add Unit Tests and ideally run ReSharper code inspections

## Deploying

* Change major/minor versions in `appveyor.yml` if needed (build number is handled by AppVeyor)
* Update `CHANGELOG.md` to note expected build number after AppVeyor runs
* The NuGet package is automatically generated on AppVeyor and deployed to NuGet.org
* Create a git tag in the `v1.2.3` format