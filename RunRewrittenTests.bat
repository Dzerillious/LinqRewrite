cd Tests\TestsLibrary
dotnet restore
cd ..\..

cd LinqRewrite
dotnet run ..\Tests\TestsLibrary\TestsLibrary.csproj ..\Tests\Rewritten
cd ..\Tests\Rewritten
dotnet run
pause