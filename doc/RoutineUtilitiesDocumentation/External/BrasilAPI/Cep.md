# Cep Record

Represents a postal code (CEP) with associated address details.

## Properties

### ZipCode

Gets or sets the postal code (CEP).
- `string? ZipCode`

### State

Gets or sets the state.
- `string? State`

### City

Gets or sets the city.
- `string? City`

### Neighborhood

Gets or sets the neighborhood.
- `string? Neighborhood`

### Street

Gets or sets the street.
- `string? Street`

### Service

Gets or sets the service provider.
- `string? Service`

### Location

Gets or sets the location details.
- `CepLocation? Location`

# CepLocation Record

Represents the location details associated with a CEP.

## Properties

### Type

Gets or sets the type of location.
- `string? Type`

### Coordinates

Gets or sets the coordinates of the location.
- `CepCoordinates? Coordinates`

# CepCoordinates Record

Represents the geographical coordinates of a location.

## Properties

### Longitude

Gets or sets the longitude.
- `string? Longitude`

### Latitude

Gets or sets the latitude.
- `string? Latitude`