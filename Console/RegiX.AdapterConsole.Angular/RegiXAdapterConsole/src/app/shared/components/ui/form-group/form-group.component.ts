import { Component, OnInit, Input, ContentChild } from '@angular/core';
import { ValidationErrors } from '@angular/forms';
import { FormGroupRefDirective } from '../../../directives/form-group-ref.directive';

enum EValidators {
  REQUIRED = 'required',
  MINLENGHT = 'minlength',
  MAXLENGHT = 'maxlength',
  PATTERN = 'pattern',
  EMAIL = 'email',
  mustMatch = 'mustMatch'
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
      'За да използвате този компонент, трябва да добавите appFormGroupRef директивата.'
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
          message = 'Това поле е задължитено.';
          break;
        }
        case EValidators.MINLENGHT: {
          message = `Полето трябва да е поне ${errorMeta.requiredLength} символа. Вие сте въвели ${errorMeta.actualLength} символа.`;
          break;
        }
        case EValidators.MAXLENGHT: {
          message = `Полето трябва да не е по-дълго от ${errorMeta.requiredLength} символа. Вие сте въвели ${errorMeta.actualLength} символа.`;
          break;
        }
        case EValidators.PATTERN: {
          message = `Полето трябва да отговаря на маска [${errorMeta.requiredPattern}]`;
          break;
        }
        case EValidators.EMAIL: {
          message = `Моля въведете коректен e-mail адрес (example@test.com)`;
          break;
        }
        case EValidators.mustMatch: {
          message = `Паролата не съвпада!`;
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
