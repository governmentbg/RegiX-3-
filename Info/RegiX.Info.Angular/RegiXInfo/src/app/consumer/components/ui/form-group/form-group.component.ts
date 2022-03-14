import { Component, OnInit, ContentChild } from '@angular/core';
import { FormGroupRefDirective } from '@tl/tl-common';
import { ValidationErrors } from '@angular/forms';

enum EValidators {
  REQUIRED = 'required',
  MINLENGHT = 'minlength'
}

@Component({
  selector: 'app-form-group',
  templateUrl: './form-group.component.html',
  styleUrls: ['./form-group.component.scss']
})
export class FormGroupComponent implements OnInit {
  @ContentChild(FormGroupRefDirective)
  input: FormGroupRefDirective;

  constructor() {}

  get isError() {
    if (this.input) {
      return this.input.hasError;
    }

    throw new Error(
      'За да използвате този компонент, трябва да добавите tlFormGroupRef директивата.'
    );
  }

  get errorMessages() {
    const errors = this.input.errors;
    const messages = [];

    const keys = Object.keys(errors);

    keys.forEach(errorKey => {
      const message = this.getErrorMessage(errorKey, errors);
      if (message) {
        messages.push(message);
      }
    });

    return messages;
  }

  private getErrorMessage(errorKey: string, errors: ValidationErrors | '') {
    let message: string;
    const errorMeta = errors[errorKey];

    if (errorMeta) {
      switch (errorKey) {
        case EValidators.REQUIRED: {
          message = 'Полето е задължитено.';
          break;
        }
        case EValidators.MINLENGHT: {
          message = `Полето трябва да е поне ${
            errorMeta.requiredLength
          } символа. Вие сте въвели ${errorMeta.actualLength} символа.`;
          break;
        }
        default: {
          message = `За валидатор ${errorKey} няма добавено съобщение.`;
        }
      }
    }

    return message;
  }

  ngOnInit() {}
}
