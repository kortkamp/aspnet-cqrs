# SysLog, a CQRS POC in ASPNET

This project was built with the aim of studying how to work with CQRS and DDD in an ASPNET API.


## Issues 

I was having some troubles when building the solution, sometimes I've been getting warning for rules disabled in .editorconfig and sometimes the behavior was like expected.
After extensive search and some pain I've found it was a Bug described in https://github.com/dotnet/vscode-csharp/issues/5885
There are two possibles fix for the issue:
- Set environment variable MSBUILDDISABLENODEREUSE=1  
- Run dotnet build-server shutdown 


## Linting and Static Code Analysis 

After some research I decided to use StyleCop.Analyzers and SonarAnalyzer.CSharp packages in order to improve my code quality, but I've disabled some rules in editorconfig. The packages are listed in /src/Directory.Build.props in order to be used on all projects. I'm expecting to use the same packages configuration on future projects.