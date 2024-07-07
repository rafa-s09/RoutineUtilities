# BrazilDocumentValidation Class

> Provides methods for validating various brazilian document formats such as CPF, CNPJ, and PIS.

## Methods

[[#ValidatesCPF]]
[[#ValidatesCNPJ]]
[[#ValidatesPIS]]
[[#IsCPFValid]]
[[#IsCNPJValid]]
[[#IsPISValid]]

### ValidatesCPF

Validates a CPF (Brazilian individual taxpayer registry identification).
#### Parameters
- `string cpf`: The CPF string to validate.
#### Returns
- `DocumentValidationResponse`: Indicates whether the CPF is valid, invalid, or the wrong size.

### ValidatesCNPJ

Validates a CNPJ (Brazilian National Registry of Legal Entities).
#### Parameters
- `string cnpj`: The CNPJ string to validate.
#### Returns
- `DocumentValidationResponse`: Indicates whether the CNPJ is valid, invalid, or the wrong size.

### ValidatesPIS

Validates a PIS (Brazilian Social Integration Program) number.
#### Parameters
- `string pis`: The PIS string to validate.
#### Returns
- `DocumentValidationResponse`: Indicates whether the PIS is valid, invalid, or the wrong size.

### IsCPFValid

Checks if a CPF (Brazilian individual taxpayer registry identification) is valid.
#### Parameters
- `string cpf`: The CPF string to validate.
#### Returns
- `bool`: True if the CPF is valid; otherwise, false.

### IsCNPJValid

Checks if a CNPJ (Brazilian National Registry of Legal Entities) is valid.
#### Parameters
- `string cnpj`: The CNPJ string to validate.
#### Returns
- `bool`: True if the CNPJ is valid; otherwise, false.

### IsPISValid

Checks if a PIS (Brazilian Social Integration Program) number is valid.
#### Parameters
- `string pis`: The PIS string to validate.
#### Returns
- `bool`: True if the PIS is valid; otherwise, false.