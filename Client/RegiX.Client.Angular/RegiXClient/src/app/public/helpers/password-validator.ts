

import { FormControl } from '@angular/forms';
import { ValidationResult } from './validation-result';

export class PasswordValidator {

    public static strongPass(control: FormControl): ValidationResult {
        //let result =/(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{6,}/.test(control.value);
        let hasLetter = /[a-z]/.test(control.value);
        let hasCapitalLetter = /[A-Z]/.test(control.value);
        let hasDigit = /[0-9]/.test(control.value);
        let hasNonAlphanumericCharacter = /[^a-zA-Z\d\s:]/.test(control.value);
  
        const valid = hasLetter && hasCapitalLetter && hasDigit && hasNonAlphanumericCharacter;
        if (!valid) {
            // return what´s not valid
            return { strongPass: true };
        }
        return null;
    }
}