

dotnet build -c release -o .\PinionCyber.NetCode\Assets\PinionCyber.NetCode\Regulus\Regulus.Remote .\Regulus.Remote\Regulus.Remote.Server 
dotnet build -c release -o .\PinionCyber.NetCode\Assets\PinionCyber.NetCode\Regulus\Regulus.Remote .\Regulus.Remote\Regulus.Remote.Client
dotnet build -c release -o .\PinionCyber.NetCode\Assets\PinionCyber.NetCode\Regulus\Regulus.Remote .\Regulus.Remote\Regulus.Remote.Standalone


dotnet build --no-dependencies -c release -o .\PinionCyber.NetCode\Assets\PinionCyber.NetCode\Regulus\Regulus.Remote  .\Regulus.Remote\Regulus.Remote.Tools.Protocol.Sources\

