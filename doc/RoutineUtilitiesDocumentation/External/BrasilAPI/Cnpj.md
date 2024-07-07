# Cnpj Record

Represents a Brazilian National Registry of Legal Entities (CNPJ) with associated details.

## Properties

### CnpjNumber

Gets or sets the CNPJ number.
- `string? CnpjNumber`

### BranchMatrixIdentifier

Gets or sets the branch/matrix identifier.
- `int? BranchMatrixIdentifier`

### BranchOfficeDescription

Gets or sets the branch office description.
- `string? BranchOfficeDescription`

### CorporateName

Gets or sets the corporate name.
- `string? CorporateName`

### FantasyName

Gets or sets the fantasy name.
- `string? FantasyName`

### RegistrationStatus

Gets or sets the registration status.
- `int? RegistrationStatus`

### DescriptionOfRegistrationStatus

Gets or sets the description of the registration status.
- `string? DescriptionOfRegistrationStatus`

### RegistrationStatusDate

Gets or sets the registration status date.
- `string? RegistrationStatusDate`

### ReasonForRegistrationStatus

Gets or sets the reason for the registration status.
- `int? ReasonForRegistrationStatus`

### OuterCityName

Gets or sets the name of the city in the exterior.
- `string? OuterCityName`

### CodeLegalNature

Gets or sets the code of the legal nature.
- `int? CodeLegalNature`

### ActivityStartDate

Gets or sets the activity start date.
- `string? ActivityStartDate`

### FiscalCnae

Gets or sets the fiscal CNAE (National Classification of Economic Activities).
- `int? FiscalCnae`

### CnaeFiscalDescription

Gets or sets the description of the fiscal CNAE.
- `string? CnaeFiscalDescription`

### StreetTypeDescription

Gets or sets the street type description.
- `string? StreetTypeDescription`

### Street

Gets or sets the street name.
- `string? Street`

### Number

Gets or sets the street number.
- `string? Number`

### Complement

Gets or sets the complement.
- `string? Complement`

### Neighborhood

Gets or sets the neighborhood.
- `string? Neighborhood`

### ZipCode

Gets or sets the postal code (CEP).
- `string? ZipCode`

### UF

Gets or sets the state abbreviation (UF).
- `string? UF`

### CityCode

Gets or sets the city code.
- `int? CityCode`

### City

Gets or sets the city name.
- `string? City`

### PhoneDDD1

Gets or sets the first phone DDD.
- `string? PhoneDDD1`

### PhoneDDD2

Gets or sets the second phone DDD.
- `string? PhoneDDD2`

### FaxDDD

Gets or sets the fax DDD.
- `string? FaxDDD`

### QualificationOfTheResponsible

Gets or sets the qualification of the responsible.
- `int? QualificationOfTheResponsible`

### ShareCapital

Gets or sets the share capital.
- `long? ShareCapital`

### Size

Gets or sets the size of the company.
- `string? Size`

### SizeDescription

Gets or sets the size description.
- `string? SizeDescription`

### OptingForTheSimple

Gets or sets a value indicating whether the company is opting for the simple tax regime.
- `bool? OptingForTheSimple`

### DateOptionForSimple

Gets or sets the date of the option for the simple tax regime.
- `string? DateOptionForSimple`

### ExclusionDateForSimple

Gets or sets the exclusion date for the simple tax regime.
- `string? ExclusionDateForSimple`

### OptingForMei

Gets or sets a value indicating whether the company is opting for MEI.
- `bool? OptingForMei`

### SpecialSituation

Gets or sets the special situation.
- `string? SpecialSituation`

### DateSpecialSituation

Gets or sets the date of the special situation.
- `string? DateSpecialSituation`

### SecundaryCnaes

Gets or sets the list of secondary CNAEs.
- `List<Cnaes>? SecundaryCnaes`

### Qsa

Gets or sets the list of QSA (Quadro de Sócios e Administradores).
- `List<Qsa>? Qsa`

# Cnaes Record

Represents a secondary CNAE (National Classification of Economic Activities).

## Properties

### Code

Gets or sets the code of the CNAE.
- `int? Code`

### Description

Gets or sets the description of the CNAE.
- `string? Description`

# Qsa Record

Represents a member of the QSA (Quadro de Sócios e Administradores).

## Properties

### BusinessPartnerIdentifier

Gets or sets the identifier of the business partner.
- `int? BusinessPartnerIdentifier`

### `BusinessPartnerName`

Gets or sets the name of the business partner.
- `string? BusinessPartnerName`

### BusinessPartnerDocumentNumber

Gets or sets the document number (CNPJ/CPF) of the business partner.
- `string? BusinessPartnerDocumentNumber`

### PartnerQualificationCode

Gets or sets the partner qualification code.
- `int? PartnerQualificationCode`

### ShareCapitalPercentage

Gets or sets the share capital percentage.
- `int? ShareCapitalPercentage`

### CompanyEntryDate

Gets or sets the company entry date.
- `string? CompanyEntryDate`

### CpfLegalRepresentative

Gets or sets the CPF of the legal representative.
- `string? CpfLegalRepresentative`

### LegalRepresentativeName

Gets or sets the name of the legal representative.
- `string? LegalRepresentativeName`

### LegalRepresentativeQualificationCode

Gets or sets the qualification code of the legal representative.
- `int? LegalRepresentativeQualificationCode`
