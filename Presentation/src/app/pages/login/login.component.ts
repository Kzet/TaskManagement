import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, NonNullableFormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzTabsModule } from 'ng-zorro-antd/tabs';
import { AuthService } from '../../services/auth.service';
import { AuthRequest } from '../../models/user/authRequest.model';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  imports: [CommonModule,
    NzLayoutModule,
    NzFormModule,
    NzButtonModule,
    NzInputModule,
    ReactiveFormsModule,
    NzTabsModule,
    NzDividerModule,
    NzIconModule,
    NzCheckboxModule,
    NzSelectModule,
    NzDatePickerModule, RouterLink],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  validateForm: FormGroup<{
    email: FormControl<string>;
    password: FormControl<string>;
  }>;

  passwordVisible = false;
  loading: boolean = false;



  constructor(private fb: NonNullableFormBuilder,
    private messageService: NzMessageService,
    private authService: AuthService,
    private router: Router)
  {
    this.validateForm = this.fb.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
  }


  submitForm() {
    if (this.validateForm.valid) {
      this.loading = true;
      this.validateForm.patchValue({ email: this.validateForm.value.email.trim() });
      let login: AuthRequest = this.validateForm.value as AuthRequest;
      this.authService.login(login).subscribe({
        next: (res) => {
          if (res.resetToken != null) {
            this.router.navigate(['/reset-password'], { state: { email: this.validateForm.value.email, resetToken: res.resetToken } });
          } else {
            this.router.navigateByUrl('/');
          }
        },
        error: (err: HttpErrorResponse) => {
          //this.loading = false;
          //this.messageService.error(err.error.Message);
        }
      }).add(() => {
        this.loading = false;
      });
    } else {
      Object.values(this.validateForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }
}
