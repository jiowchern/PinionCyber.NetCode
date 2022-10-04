

dotnet build -c release -o .\PinionCyber.NetCode\Assets\PinionCyber.NetCode\Protocols\Regulus\Regulus.Remote .\Regulus.Remote\Regulus.Remote.Server 
dotnet build -c release -o .\PinionCyber.NetCode\Assets\PinionCyber.NetCode\Protocols\Regulus\Regulus.Remote .\Regulus.Remote\Regulus.Remote.Client
dotnet build -c release -o .\PinionCyber.NetCode\Assets\PinionCyber.NetCode\Protocols\Regulus\Regulus.Remote .\Regulus.Remote\Regulus.Remote.Standalone


dotnet publish -c release -o .\PinionCyber.NetCode\Assets\PinionCyber.NetCode\Protocols\Regulus\Regulus.Remote  .\Regulus.Remote\Regulus.Remote.Tools.Protocol.Sources\

