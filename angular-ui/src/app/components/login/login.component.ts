import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import ValidateForm from '../../helpers/validateform';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent implements OnInit {
  typ: string = 'password';
  isText: boolean = false;
  eyeIcon: string = 'fa-eye-slash';

  loginForm!: FormGroup;
  constructor(
    private fb: FormBuilder,
    private auth: AuthService,
    private router: Router
  ) {}

  onLogin() {
    if (this.loginForm.valid) {
      console.log(this.loginForm.value);
      this.auth.login(this.loginForm.value).subscribe({
        next: (res) => {
          //this.toast.success({detail:"SUCCESS",summary:res.message, duration: 5000})
          alert(res.message);
          this.loginForm.reset();
          this.auth.storeToken(res.token);
          this.router.navigate(['dashboard']);
        },
        error: (err) => {
          console.error('Error:', err);
          const errorMessage =
            err && err.error && err.error.message
              ? err.error.message
              : 'An error occurred';
          alert(errorMessage);
        },
      });
    } else {
      ValidateForm.validateAllFormFields(this.loginForm);
    }
  }

  ngOnInit(): void {
    if (this.auth.isLoggedIn()) {
      this.auth.logOut();
    }
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  hideShowPass() {
    this.isText = !this.isText;
    this.isText ? (this.eyeIcon = 'fa-eye') : (this.eyeIcon = 'fa-eye-slash');
    this.isText ? (this.typ = 'text') : (this.typ = 'password');
  }
}
