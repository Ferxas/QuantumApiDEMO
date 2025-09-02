# Quantum Q# API (QDK + .NET 8 Minimal API)

Minimal API built with **ASP.NET Core (.NET 8)** that exposes operations written in **Q#** using the **Quantum Simulator** from the Microsoft Quantum Development Kit (QDK).

## Features

- **GET `/rng`** → returns a quantum random bit (`Zero` or `One`).
- **GET `/measure?theta=<rad>`** → applies a `Ry(theta)` rotation to a qubit and measures (`Zero`/`One`).

> Note: This runs on the **classical simulator** (`QuantumSimulator`), not real quantum hardware.

---

## Requirements

- **.NET SDK 8.0**  
  (recommended: pin SDK with `global.json` if your system defaults to .NET 9)
- Linux, macOS, or Windows (works fine on **WSL**)
- Templates are **not required** to build/run this repo.  
  Only if you want to create new Q# projects:  
  ```bash
  dotnet new install Microsoft.Quantum.ProjectTemplates
  ```

## Project Structure
```
QuantumApi.sln
QuantumLib/
  ├─ QuantumLib.csproj          # <Project Sdk="Microsoft.Quantum.Sdk/0.28.x">
  └─ Operations.qs              # Q# (RandomBit, FlipAndMeasure)
QuantumApi/
  ├─ QuantumApi.csproj          # <Project Sdk="Microsoft.NET.Sdk.Web">
  ├─ Program.cs                 # Endpoints /rng and /measure
  └─ Properties/launchSettings.json
```

## Run Locally
1) Restore and build
```bash
dotnet restore
dotnet build
```

2) Run (two options)
- A. Use the port from launch profile (e.g. 5110):
```
dotnet run --project QuantumApi/QuantumApi.csproj
# Output: Now listening on: http://localhost:5110
```

- B. Force a custom port (ignore launch profile):

```ASPNETCORE_URLS=http://localhost:5000 dotnet run --project QuantumApi/QuantumApi.csproj --no-launch-profile
# Output: Now listening on: http://localhost:5000
```

Expose outside WSL / local network:
```
ASPNETCORE_URLS=http://0.0.0.0:5000 dotnet run --project QuantumApi/QuantumApi.csproj --no-launch-profile
```

## Test Endpoints

Assuming http://localhost:5000:
```
curl http://localhost:5000/rng
# {"result":"Zero"} or {"result":"One"}

curl "http://localhost:5000/measure?theta=1.2"
# {"theta":1.2,"result":"Zero"} or {"theta":1.2,"result":"One"}
```