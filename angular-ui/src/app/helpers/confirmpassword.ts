import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export default class ConfirmPassword {
  static matchPassword: ValidatorFn = (
    control: AbstractControl
  ): ValidationErrors | null => {
    let password = control.get('password');
    let confirmpassword = control.get('confirmPassword');
    if (
      password &&
      confirmpassword &&
      password?.value != confirmpassword?.value &&
      confirmpassword?.value != ''
    ) {
      return {
        confirmPasswordError: true,
      };
    }
    return null;
  };
}
