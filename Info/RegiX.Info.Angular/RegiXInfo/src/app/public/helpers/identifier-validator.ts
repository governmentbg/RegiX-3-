import { FormControl } from '@angular/forms';
import { ValidationResult } from './validation-result';

export class IdentifierValidator {

    public static validateIdentifier(control: FormControl): ValidationResult {
        let hasDigit = /^[0-9]+$/.test(control.value);

        const valid = hasDigit ;
        if (!valid) {
            // return what´s not valid
            return { validateIdentifier: true };
        }
        return null;
    }
}