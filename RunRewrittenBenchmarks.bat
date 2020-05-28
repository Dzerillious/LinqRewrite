cd Tests\BenchmarksLibrary
dotnet restore
cd ..\..

cd LinqRewrite
dotnet run ..\Tests\BenchmarksLibrary\BenchmarksLibrary.csproj ..\Tests\Rewritten
cd ..\Tests\Rewritten
dotnet run --configuration Release
pause