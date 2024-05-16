# VIN Validador Scania Hack 2024
* PRODUCT team (Forsberg Christer, Oldenkamp Emiel)
* KOTLIN team (Vaddi Shanmukha, Oldenkamp Emiel, Caccin Giulio)
* Typescript team (Dhanore Yash, Palmér Samuel, Caccin Giulio)
* .NET team (Selvad Niclas, Vañó Igual Ximo, Borro Diana) - [.NET Vin Validator](https://github.com/vinner-it/vinner-it-dotnet)
* C++ (Emami Mohsen, Caccin Giulio)

# VIN Standard Summary

## Introduction
This repository contains the details and implementation guidelines for the ISO 3779:2009 standard, which specifies the content and structure of the Vehicle Identification Number (VIN). The VIN system is used globally to provide a unique identifier for road vehicles, including motor vehicles, towed vehicles, motorcycles, and mopeds.

## Scope
The ISO 3779:2009 standard establishes a uniform identification numbering system for road vehicles. It ensures that each vehicle has a unique VIN that remains consistent for 30 years. This standard applies to all road vehicles as defined in ISO 3833.

## Structure of the VIN
The VIN is composed of three sections:

1. **World Manufacturer Identifier (WMI):** The first section, consisting of three characters, identifies the manufacturer of the vehicle. These characters are assigned by the national organization of the manufacturer's country.

2. **Vehicle Descriptor Section (VDS):** The second section consists of six characters (alphabetical or numerical) determined by the manufacturer. This section describes the general attributes of the vehicle.

3. **Vehicle Indicator Section (VIS):** The third section consists of eight characters, the last four of which are numerical. This section uniquely identifies the specific vehicle and can include information about the model year and manufacturing plant.

## Key Elements and Requirements
- **Characters Used:** The VIN uses a specific set of characters, avoiding the letters I, O, and Q to prevent confusion.
- **Dividers:** Manufacturers may use dividers to separate VIN sections, but these cannot be characters used in the VIN itself or any character that could be confused with VIN characters.
- **Display:** The VIN must be displayed on one line without blanks in documentation. On vehicles or manufacturer’s plates, it can be shown on one or two lines, again without blanks and without splitting sections.

## Compliance and Responsibility
- **Manufacturer's Responsibility:** The manufacturer is responsible for ensuring the uniqueness of the VIN and compliance with the standard. This responsibility can be delegated to a subsidiary company.
- **Year and Model Designation:** The VIS section can include the year and manufacturing plant. A recommended code for designating the year is provided in the standard.

## References
The following documents are indispensable for the application of the ISO 3779:2009 standard:
- ISO 3780: Road vehicles — World manufacturer identifier (WMI) code
- ISO 3833: Road vehicles — Types — Terms and definitions
- ISO 4030: Road vehicles — Vehicle identification number (VIN) — Location and attachment

## Examples
The standard provides several examples of VIN formats to illustrate its application.

For more detailed information, refer to the full ISO 3779:2009 document. This summary serves as an overview and guide for understanding and implementing the VIN standard in vehicle manufacturing and identification processes.
