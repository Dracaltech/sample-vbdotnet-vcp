# sample-vbdotnet-vcp
Dracal // SDK code sample for VB (.NET) on VCP

## Assumptions

Running this repository requires you to have installed:
- .NET (version >= `8.0`)
- Visual Studio (version >= 2022)


## Simple usage

Run by
- Using the **Play** button (Visual Studio)
- Build and run using the command line:

```
dotnet run sample-vbdotnet-vcp.sln
```


## Sample output
<img src="https://github.com/Dracaltech/sample-csharp-vcp/assets/1357711/8f34fdfd-0383-427a-8adc-3330b847430c" width=400 />

```
Awaiting info line...
Awaiting info line...
Printing 2 fractional digits
I,Product ID,Serial Number,Message,MS5611 Pressure,Pa,SHT31 Temperature,C,SHT31 Relative Humidity,%,
2024-05-01 17:30:42

VCP-PTH450-CAL E24638
MS5611 Pressure           101834 Pa
SHT31 Temperature         22.20 C
SHT31 Relative Humidity   47.33 %
2024-05-01 17:30:43

VCP-PTH450-CAL E24638
MS5611 Pressure           101832 Pa
SHT31 Temperature         22.20 C
SHT31 Relative Humidity   47.34 %
2024-05-01 17:30:44

VCP-PTH450-CAL E24638
MS5611 Pressure           101833 Pa
SHT31 Temperature         22.19 C
SHT31 Relative Humidity   47.34 %
2024-05-01 17:30:45

VCP-PTH450-CAL E24638
MS5611 Pressure           101835 Pa
SHT31 Temperature         22.22 C
SHT31 Relative Humidity   47.35 %
2024-05-01 17:30:46
```