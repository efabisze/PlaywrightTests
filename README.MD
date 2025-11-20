dotnet test --settings ./profiles/DEV.runsettings

dotnet test --filter "TestCategory=Smoke"
[AllureSuite("Login Tests")]
