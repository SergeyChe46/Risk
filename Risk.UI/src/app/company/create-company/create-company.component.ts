import { Component } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { CompanyService } from 'src/app/company.service';
import { ICompany } from 'src/app/shared/company';

@Component({
  selector: 'app-create-company',
  templateUrl: './create-company.component.html',
  styleUrls: ['./create-company.component.css'],
})
export class CreateCompanyComponent {
  companyForm: FormGroup;

  constructor(
    private httpService: CompanyService,
    public fb: FormBuilder,
    private router: Router
  ) {
    this.companyForm = this.fb.group({
      id: new FormControl('00000000-0000-0000-0000-000000000000'),
      name: new FormControl('', Validators.required),
      city: new FormControl('', Validators.required),
      phone: new FormControl('', [
        Validators.minLength(5),
        Validators.maxLength(15),
      ]),
    });
  }
  get companyName() {
    return this.companyForm.get('name') as FormControl;
  }
  get companyPhone() {
    return this.companyForm.get('phone') as FormControl;
  }

  create() {
    this.httpService.createCompany(this.companyForm.value);
    this.router.navigate(['/']);
  }
}
