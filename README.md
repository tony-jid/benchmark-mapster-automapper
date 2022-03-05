# Benchmark .NET Mapster vs AutoMapper

- Demonstrate how to use Mapster and AutoMapper in .NET
- Benchmarking performance between Mapster and AutoMapper

### Conclusions
- Mapster performs better than AutoMapper
- Mapster Tool facilitates generating DTO classes and mappers
- Mapster CodeGen Mapper outperforms AutoMapper as well as general Mapster

![image](https://user-images.githubusercontent.com/16954516/156876976-4022efbd-4220-4c21-9af4-1e7e5fef6fa8.png)

### Install Mapster package
```
Install-Package Mapster
```

### Mapster Tool to generate DTO classes and mappers
- Install Mapster Tool
```
#skip this step if you already have dotnet-tools.json
dotnet new tool-manifest
dotnet tool install Mapster.Tool
```
   
- Integrating Mapster with `csproj`
  - Adding the codes below to `csproj` file.
```html
<ItemGroup>
  <Generated Include="**\*.g.cs" /> <!--Defining variable to return all files with the specified suffix-->
</ItemGroup>  
<Target Name="CleanGenerated"> <!--Defining the build target name -->
  <Delete Files="@(Generated)" /> <!--Delete all files found returned from Generated variable-->
</Target>
<Target Name="Mapster"> <!--Defining the build target name-->
  <Exec WorkingDirectory="$(ProjectDir)" Command="dotnet build" />
  <Exec WorkingDirectory="$(ProjectDir)" Command="dotnet tool restore" />
  <Delete Files="@(Generated)" /> <!--Cleaning all generated files before generating new ones. This must be after dotnet build to avoid compile error of any CodeGen class reference-->
  <Exec WorkingDirectory="$(ProjectDir)" Command="dotnet mapster model -a &quot;$(TargetDir)$(ProjectName).dll&quot; -n BenchmarkMapper.Domains.CodeGen -o Domains/CodeGen/Models" /> <!--option:n defines namespace of a generated DTO, option:o defines outlet directory-->
  <Exec WorkingDirectory="$(ProjectDir)" Command="dotnet mapster extension -a &quot;$(TargetDir)$(ProjectName).dll&quot; -n BenchmarkMapper.Domains.CodeGen -o Domains/CodeGen/Mappers" /> <!--option:n defines namespace of a generated mapper, option:o defines outlet directory-->
  <Exec WorkingDirectory="$(ProjectDir)" Command="dotnet mapster mapper -a &quot;$(TargetDir)$(ProjectName).dll&quot; -n BenchmarkMapper.Domains.CodeGen" />
</Target>
```
- Running the following command to generate DTOs and mappers
```
dotnet msbuild -t:Mapster
#or
dotnet msbuild --target:Mapster
```

### References
- https://www.infoworld.com/article/3573782/how-to-benchmark-csharp-code-using-benchmarkdotnet.html
- https://github.com/MapsterMapper/Mapster
- https://dotnettutorials.net/lesson/automapper-in-c-sharp/
