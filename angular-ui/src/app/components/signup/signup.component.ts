import { Component, OnInit } from '@angular/core';
import ValidateForm from '../../helpers/validateform';
import ConfirmPassword from '../../helpers/confirmpassword';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css',
})
export class SignupComponent implements OnInit {
  typ: string = 'password';
  isText: boolean = false;
  eyeIcon: string = 'fa-eye-slash';
  signUpForm!: FormGroup;

  constructor(private fb: FormBuilder, private auth: AuthService) {}

  ngOnInit(): void {
    this.signUpForm = this.fb.group(
      {
        firstName: [
          null,
          Validators.compose([
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(50),
          ]),
        ],
        lastName: [
          null,
          Validators.compose([
            Validators.required,
            Validators.minLength(2),
            Validators.maxLength(50),
          ]),
        ],
        email: [
          null,
          Validators.compose([Validators.required, Validators.email]),
        ],
        password: [
          '',
          [
            Validators.required,
            Validators.pattern(
              /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/
            ),
          ],
        ],
        confirmPassword: ['', Validators.required],
      },
      {
        validators: ConfirmPassword.matchPassword,
      }
    );
  }

  onSignup() {
    if (this.signUpForm.valid) {
      console.log(this.signUpForm.value);
      this.auth.signUp(this.signUpForm.value).subscribe({
        next: (res) => {
          alert(res.message);
        },
        error: (err) => {
          alert(err?.error.message);
        },
      });
    } else {
      ValidateForm.validateAllFormFields(this.signUpForm);
    }
  }

  hideShowPass() {
    this.isText = !this.isText;
    this.isText ? (this.eyeIcon = 'fa-eye') : (this.eyeIcon = 'fa-eye-slash');
    this.isText ? (this.typ = 'text') : (this.typ = 'password');
  }
}
